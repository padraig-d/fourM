function getGameOptions() {
    var gamemodeSettings = [];
    var gamemodeSettingsTable = document.getElementById("gamemode-settings-table");
    var rowLength = gamemodeSettingsTable.rows.length;

    for (i = 0; i < rowLength; i++) {
        var gamemodeSettingCells = gamemodeSettingsTable.rows.item(i).cells;
        var cellLength = gamemodeSettingCells.length;

        var key = gamemodeSettingCells.item(0).innerHTML;
        var value = gamemodeSettingCells.item(1).innerHTML;

        gamemodeSettings[key] = value;
    }

    return gamemodeSettings
}
