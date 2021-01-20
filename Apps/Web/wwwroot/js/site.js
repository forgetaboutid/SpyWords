var gameState = {};
LoadGame();
//var loadGameInterval = setInterval(LoadGame, 5000);

var teamColors = {};
teamColors[1] = "red";
teamColors[2] = "blue";
teamColors[3] = "grey";
teamColors[4] = "black";
function LoadGame() {
    var requestStr = "/gameState";
    $.get(requestStr, function (data, status) {
        if (status === "error") {
            //clearInterval(loadGameInterval);

            alert("Error loading game.");
        }
        if (status === "success") {
            gameState = data;
            if (gameState.cards === undefined) {
                NewGame();
            }
            else {
                writeWordsOnCards(gameState.cards);
            }
        }
    });
}

function SaveGame() {

    $.ajax({
        url: '/gameState',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(gameState)
    });

}

function writeWordsOnCards(cards) {
    for (var i = 0; i < cards.length; i++) {
        var cell = document.getElementById(i);
        cell.textContent = cards[i].word;
        cell.style.backgroundColor = "tan";
        cell.onclick = showColor;
    }
}

function showColor() {
    this.style.backgroundColor = teamColors[gameState.cards[this.id].team];
    SaveGame();
}

function NewGameClick() {
    setTimeout(function () {
        var r = confirm("Game Over?");
        if (r == true) {
            NewGame();
        }
    }, 200);
}

function NewGame() {

}


