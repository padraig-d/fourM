function getGameOptions() {
    var gamemodeSettings = [];
    var gamemodeSettingsTable = document.getElementById("gamemode-settings-table");
    var rowLength = gamemodeSettingsTable.rows.length;

    for (i = 0; i < rowLength; i++) {
        var gamemodeSettingCells = gamemodeSettingsTable.rows.item(i).cells;

        var key = gamemodeSettingCells.item(0).textContent;
        var value = gamemodeSettingCells.item(1).textContent;

        gamemodeSettings[key] = value;
    }

    return gamemodeSettings
}

function setGamemodeSetting(key, value) {

    if (key == null || value == null) return;

    var gamemodeSettingsTable = document.getElementById("gamemode-settings-table");
    var rowLength = gamemodeSettingsTable.rows.length;

    for (i = 0; i < rowLength; i++) {
        var gamemodeSettingCells = gamemodeSettingsTable.rows.item(i).cells;

        var currKey = gamemodeSettingCells.item(0).textContent;
        var currValue = gamemodeSettingCells.item(1);

        if (currKey == key) {
            currValue.textContent = value;
        }
    }
}


function setCountdownTimerValue(value) {
    if (value == null) return;

    var countdownTimer = document.getElementById("countdown-timer");
    countdownTimer.textContent = "Starting in " + value;
}


function startCountdownTimer(seconds) {
    if (seconds == null) return;
    
    // Code below is repeated because theres a delay before setInterval runs (WHY?!)
    setCountdownTimerValue(seconds);
    seconds--;

    var interval = setInterval(function(){
        if (seconds <= 0) {
            clearInterval(interval);
        }

        setCountdownTimerValue(seconds);
        seconds--;
    }, 1000);
}
