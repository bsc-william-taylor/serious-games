
const url = require('url');

const ENGAGE_URL = "http://engage.yaellechaudy.com:8080";
const VERSION = 0;
const GAMEID = 329;
const LIMIT = 100;

const LEADERBOARD_URL = `/learninganalytics/leaderboard/${LIMIT}/seriousgame/${GAMEID}/version/${VERSION}`;
const INFO_URL = `/seriousgame/info/${GAMEID}/version/${VERSION}`;
const GAME_START = `/gameplay/startGP`;
const LOGS_URL = `/gameplay/${GAMEID}/log`;
const LGN_URL = `/SGaccess`;

module.exports = {
    uniqueIdentifier: GAMEID,
    version: VERSION,

    leaderboard: url.resolve(ENGAGE_URL, LEADERBOARD_URL),
    login: url.resolve(ENGAGE_URL, LGN_URL),
    info: url.resolve(ENGAGE_URL, INFO_URL),
    logs: url.resolve(ENGAGE_URL, LOGS_URL),
    gs: url.resolve(ENGAGE_URL, GAME_START),
    
    assess: gameplayID => url.resolve(ENGAGE_URL, `gameplay/${gameplayID}/assessAndScore`),
    gameLose: gameplayID => url.resolve(ENGAGE_URL, `/gameplay/${gameplayID}/end/lose`),
    gameWin: gameplayID => url.resolve(ENGAGE_URL, `/gameplay/${gameplayID}/end/win`)
};