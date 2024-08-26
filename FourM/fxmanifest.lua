fx_version 'bodacious'
game 'gta5'

ui_page 'html/fourM-Lobby/index.html'

files {
    'Client/bin/Release/**/*.dll',
    'html/fourM-Lobby/*.js',
    'html/fourM-Lobby/*.css',
    'html/fourM-Lobby/*.html'
}

client_scripts {
    'Client/bin/Release/**/*.net.dll'
} 

server_script 'Server/bin/Release/**/*.net.dll'

author 'You'
version '1.0.0'
description 'Example Resource from C# Template'