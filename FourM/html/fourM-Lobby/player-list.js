function setLocalPlayerName(pName) {
    if (pName == null) return;
    
    var localPlayerElement = document.getElementById("local-player-name");
    localPlayerElement.textContent = pName;
}

function getLocalPlayerNameValue() {
    return document.getElementById("local-player-name").textContent;
}

function updatePlayerList(players) {
    if (players == null) return;

    let localPlayerName = getLocalPlayerNameValue();
    let playerListHTML = document.getElementById("player-list");

    for (const player of players) {
        if (player != localPlayerName) {
            let playerListItem = document.createElement("li");
            playerListItem.innerHTML = `<li><span>${player}</span> <label class="checkbox"><input type="checkbox" disabled><span class="checkmark"></span></label></li>`
            playerListHTML.appendChild(playerListItem);            
        }
    }
}