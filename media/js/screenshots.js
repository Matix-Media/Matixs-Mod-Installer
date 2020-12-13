import { Octokit } from "https://cdn.skypack.dev/@octokit/rest";
import { Utils } from "../app.js";

async function getScreenshots() {
    const screenshotsBox = document.querySelector("div#screenshots-list");
    const loading = document.querySelector("div#screenshots-loading");
    const screenshotModal = new bootstrap.Modal(document.querySelector("div#screenshot-modal"));
    const screenshotContainer = document.querySelector("img#screenshot-large-view");

    const screenshots = await axios({
        url: "/media/screenshots/screenshots.json",
    });

    loading.classList.add("d-none");

    var screenshotId = 0;
    screenshots.data.forEach((elem) => {
        const date = new Date(elem.created);
        var new_elem = `
        <div class="col mb-4">
            <div class="card shadow-sm overflow-hidden">
                <div
                    class="w-100 screenshot-image-box border-bottom"
                    style="
                        background-image: url('${elem.path}');
                    "
                ></div>
                <div class="card-body">
                    <p class="card-text">
                        ${elem.description}
                    </p>
                    <div class="d-flex justify-content-between align-items-center">
                        <button class="btn btn-sm btn-outline-secondary" id="open-screenshot-${screenshotId}">View</button>
                        <small
                            class="text-muted"
                            >${Utils.timeSince(date)} ago</small
                        >
                    </div>
                </div>
            </div>
        </div>
        `;

        screenshotsBox.innerHTML += new_elem;

        screenshotId++;
    });

    screenshotId = 0;
    screenshots.data.forEach((elem) => {
        document
            .querySelector(`button#open-screenshot-${screenshotId}`)
            .addEventListener("click", () => {
                screenshotContainer.setAttribute("src", elem.path);
                screenshotModal.show();
            });
        screenshotId++;
    });
}

window.addEventListener("DOMContentLoaded", function () {
    console.log("READY! - Screenshots");
    getScreenshots();
});
