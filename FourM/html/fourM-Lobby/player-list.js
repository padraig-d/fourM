"use strict";

function setLocalPlayerName(pName) {
    if (pName == null) return;
    
    const localPlayerElement = document.getElementById("local-player-name");
    localPlayerElement.textContent = pName;
}

function getLocalPlayerNameValue() {
    return document.getElementById("local-player-name").textContent;
}

function updatePlayerList(players) {
    if (players == null) return;

    const localPlayerName = getLocalPlayerNameValue();
    const playerList = document.getElementById("player-list");

    for (const playerListItem of playerList.querySelectorAll("li:not(.client-player)")) {
        playerListItem.remove();
    }

    for (const player of players) {
        if (player === localPlayerName) continue;

        const playerListItem = document.createElement("li");
        const playerName = document.createElement("span");
        const checkboxLabel = document.createElement("label");
        const checkboxInput = document.createElement("input");
        const checkmark = document.createElement("span");

        playerName.textContent = player;
        checkboxLabel.className = "checkbox";
        checkboxInput.type = "checkbox";
        checkboxInput.disabled = true;
        checkmark.className = "checkmark";

        checkboxLabel.appendChild(checkboxInput);
        checkboxLabel.appendChild(checkmark);
        playerListItem.appendChild(playerName);
        playerListItem.appendChild(document.createTextNode(" "));
        playerListItem.appendChild(checkboxLabel);
        playerList.appendChild(playerListItem);
    }
}
