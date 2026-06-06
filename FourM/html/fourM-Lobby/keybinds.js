"use strict";

document.addEventListener("keydown", function (event) {
    if (event.key === "Enter") {
        const readyButton = document.getElementById("ready-button");
        readyButton.click();
        readyButton.classList.add("button-active");
    }
});

document.addEventListener("keyup", function (event) {
    if (event.key === "Enter") {
        document.getElementById("ready-button").classList.remove("button-active");
    }
});
