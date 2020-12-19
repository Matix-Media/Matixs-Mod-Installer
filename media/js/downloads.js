import { Octokit } from "https://cdn.skypack.dev/@octokit/rest";
import { Utils } from "../app.js";

const octokit = new Octokit();

var files = {};
var latestFile;

async function getReleases() {
    const latestVersionBox = document.querySelector("div#latest");
    const latestSize = document.querySelector("span#latest-version-size");
    const latestName = document.querySelector("span#latest-version-file-name");
    var latestVersionDownload = document.querySelector("button#latest-version-download");
    const loadingBox = document.querySelector("div#versions-loading");
    const versionsBox = document.querySelector("div#all-versions");
    var totalDownloads = 0;

    const releases = await octokit.repos.listReleases({
        owner: "Matix-Media",
        repo: "Matixs-Mod-Installer",
    });

    loadingBox.classList.add("d-none");
    versionsBox.classList.remove("d-none");

    releases.data.forEach((elem) => {
        elem.assets.forEach((asset) => {
            totalDownloads += asset.download_count;
        });
    });

    releases.data[0].assets.forEach((asset) => {
        if (asset.browser_download_url.endsWith(".exe")) {
            files["latest"] = asset.browser_download_url;
            latestSize.innerHTML = Utils.bytesToSize(asset.size);
            latestName.innerHTML = `${releases.data[0].tag_name} &mdash; ${asset.name} <span class="text-light"> &mdash; ${totalDownloads} total downloads</span>`;

            latestFile = asset.browser_download_url;

            if (window.location.hash.substr(1) == "latest") {
                latestVersionDownload.classList.add("file-download-active");
            }
        }
    });

    releases.data.forEach((elem) => {
        var downloads = 0;

        elem.assets.forEach((asset) => {
            downloads += asset.download_count;
        });

        elem.assets.forEach((asset) => {
            if (asset.browser_download_url.endsWith(".exe")) {
                files[asset.id] = asset.browser_download_url;

                var active = "bg-white";

                if (window.location.hash.substr(1) == "file-" + asset.id) {
                    active = "active";
                }

                const date = new Date(asset.updated_at);
                var new_elem = `<div class="col-md-6 mb-3 mt-2" id="file-${asset.id}">
                    <div class="rounded shadow-sm p-3 file-download ${active}">
                        <a
                            href="${elem.html_url}"
                        >
                            <h5 class="d-inline-block text-orange mb-2">${elem.name}</h5>
                        </a>
                        <div class="d-flex justify-content-between">
                            <div>
                                <span class="d-block text-secondary">
                                ${Utils.getWeekdayByNum(
                                    date.getDay()
                                )} ${date.getDate()}. ${Utils.getMonthByNum(
                    date.getMonth()
                )} ${date.getFullYear()}
                                </span>
                                <span class="d-block text-secondary">${downloads} Downloads</span>
                                <span class="d-block text-black-50"
                                    >${asset.name}</span
                                >
                            </div>
                            <div class="ms-3 download-box-versions d-flex justify-content-end align-items-start">
                                <button
                                    class="btn btn-orange shadow-sm"
                                    id="download-file-${asset.id}"
                                    data-file="${asset.id}"
                                >
                                    Download (${Utils.bytesToSize(asset.size)})
                                </button>
                            </div>
                        </div>
                    </div>
                </div>`;

                versionsBox.innerHTML += new_elem;

                if (window.location.hash.substr(1) == "file-" + asset.id) {
                    document.querySelector(`div#file-${asset.id}`).scrollIntoView();
                }
            }
        });
    });

    for (const [key, value] of Object.entries(files)) {
        if (document.querySelector(`button#download-file-${key}`)) {
            document
                .querySelector(`button#download-file-${key}`)
                .addEventListener("click", (elem) => {
                    var text = elem.target.innerHTML;
                    elem.target.innerHTML = `<img src="media/loading-white.gif" class="i me-2" />Preparing...`;
                    document.querySelector("iframe#file_download_wrapper").src = value;

                    setTimeout(() => {
                        elem.target.innerHTML = text;
                    }, 2000);
                });
        }
    }

    latestVersionDownload = document.querySelector("button#latest-version-download");
    latestVersionDownload.addEventListener("click", (elem) => {
        var text = elem.target.innerHTML;
        elem.target.innerHTML = `<img src="media/loading.gif" class="i me-2" />Preparing...`;
        document.querySelector("iframe#file_download_wrapper").src = latestFile;
        setTimeout(() => {
            elem.target.innerHTML = text;
        }, 2000);
    });
}

window.addEventListener("DOMContentLoaded", function () {
    console.log("READY! - Downloads");
    getReleases();
});
