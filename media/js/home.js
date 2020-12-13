import { Octokit } from "https://cdn.skypack.dev/@octokit/rest";
import { Utils } from "../app.js";

const octokit = new Octokit();

async function getLatestRelease() {
    const loadingBox = document.querySelector("div#latest-loading");
    const latestVersionBox = document.querySelector("div#latest-version");

    const latestRelease = await octokit.repos.getLatestRelease({
        owner: "Matix-Media",
        repo: "Matixs-Mod-Installer",
    });

    var download = "";

    latestRelease.data.assets.forEach((asset) => {
        if (asset.browser_download_url.endsWith(".exe")) {
            download = `<a class="d-block" href="/downloads.html#file-${asset.id}" id="latest-version-file-download">${asset.name}</a>`;
        }
    });

    var new_elem = `<div class="mb-3">
                        <strong id="latest-version-name">${latestRelease.data.name}</strong>
                        <div id="latest-version-downloads">
                            ${download}
                        </div>
                    </div>
                    <div class="mb-3">
                        <abbr title="Date Released">Date:</abbr>
                        <span id="latest-version-date" title="${new Date(
                            latestRelease.data.published_at
                        )}">${Utils.timeSince(new Date(latestRelease.data.published_at))} ago</span>
                        <br />
                        <abbr title="Target commitish">Branch:</abbr>
                        <a
                            id="latest-version-branch"
                            target="_blank"
                            href="https://github.com/Matix-Media/Matixs-Mod-Installer/tree/${
                                latestRelease.data.target_commitish
                            }"
                            >${latestRelease.data.target_commitish}</a
                        >
                    </div>
                    <div class="mb-3">
                        <a href="https://github.com/Matix-Media/Matixs-Mod-Installer/releases">See all releases</a>
                    </div>
                    `;

    loadingBox.classList.add("d-none");
    latestVersionBox.innerHTML += new_elem;
}

window.addEventListener("DOMContentLoaded", function () {
    console.log("READY! - Home");
    getLatestRelease();
});
