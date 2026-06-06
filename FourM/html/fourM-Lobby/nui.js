"use strict";

function displayNui(display) {
    if (display) { 
        document.body.style.display = "flex";
    } else { 
        document.body.style.display = "none";
    }
}

window.addEventListener('message', (event) => {
    const data = event.data;

    if (data.type === 'display') {
        displayNui(data.display);
    } else if (data.action === 'setLocalPlayerName') {
        setLocalPlayerName(data.pName);
    } else if (data.action === 'updatePlayerList') {
        updatePlayerList(data.playerList);
    }
});
