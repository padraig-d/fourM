"use strict";

function getGameOptions() {
    const gamemodeSettings = {};
    const gamemodeSettingsTable = document.getElementById("gamemode-settings-table");
    const rowLength = gamemodeSettingsTable.rows.length;

    for (let i = 0; i < rowLength; i++) {
        const gamemodeSettingCells = gamemodeSettingsTable.rows.item(i).cells;

        const key = gamemodeSettingCells.item(0).textContent;
        const value = gamemodeSettingCells.item(1).textContent;

        gamemodeSettings[key] = value;
    }

    return gamemodeSettings;
}

function setGamemodeSetting(key, value) {

    if (key == null || value == null) return;

    const gamemodeSettingsTable = document.getElementById("gamemode-settings-table");
    const rowLength = gamemodeSettingsTable.rows.length;

    for (let i = 0; i < rowLength; i++) {
        const gamemodeSettingCells = gamemodeSettingsTable.rows.item(i).cells;

        const currKey = gamemodeSettingCells.item(0).textContent;
        const currValue = gamemodeSettingCells.item(1);

        if (currKey === key) {
            currValue.textContent = value;
        }
    }
}


function setCountdownTimerValue(value) {
    if (value == null) return;

    const countdownTimer = document.getElementById("countdown-timer");
    countdownTimer.textContent = "Starting in " + value;
}


function startCountdownTimer(seconds) {
    if (seconds == null) return;
    
    // Code below is repeated because theres a delay before setInterval runs (WHY?!)
    setCountdownTimerValue(seconds);
    seconds--;

    const interval = setInterval(function(){
        if (seconds <= 0) {
            clearInterval(interval);
        }

        setCountdownTimerValue(seconds);
        seconds--;
    }, 1000);
}
