//Game Test

var canvas = document.getElementById("gameArea");
var ctx = canvas.getContext("2d");

var score = 0;
var active;

var rightPressed = false;
var leftPressed = false;
document.addEventListener("keydown", keyDown, false);
document.addEventListener("keyup", keyUp, false);

var x = canvas.width / 2;
var y = canvas.height - 30;
var ballRadius = 10;
var dx = 2;
var dy = -2;

var paddleHeight = 10;
var paddleWidth = 75;
var paddleSpeed = 2;
var paddleX = (canvas.width - paddleWidth) / 2;



//Handles ball collitions with edges and paddle
function ballCollition() {
    if (x + dx > canvas.width - ballRadius || x + dx < ballRadius) {
        dx = -dx;
    }

    if (y + dy < ballRadius) {
        dy = -dy;
    }
    else if (y + dy > canvas.height - (ballRadius / 2)) {
        if (x > paddleX && x < (paddleX + paddleWidth)) {
            dy = -dy;
            ++score;
        }
        else {
            alert("Loser!");
            x = canvas.width / 2;
            y = canvas.height - 30;
            ballRadius = 10;
            dx = 2;
            dy = -2;
            score = 0;
            clearInterval(active);
            document.getElementById("startBtn").style.visibility = "visible";
        }
    }


}

//Changes the position of the paddle
function movePaddle() {
    if (rightPressed && paddleX < canvas.width - paddleWidth) {
        paddleX += paddleSpeed;
    }
    else if (leftPressed && paddleX > 0) {
        paddleX -= paddleSpeed;
    }
}


function drawPaddle() {
    ctx.beginPath();
    ctx.rect(paddleX, canvas.height - paddleHeight, paddleWidth, paddleHeight);
    ctx.fillStyle = "#0095DD";
    ctx.fill();
    ctx.closePath();
}

function drawBall() {
    ctx.beginPath();
    ctx.arc(x, y, ballRadius, 0, Math.PI * 2);
    ctx.fillStyle = "#0095DD";
    ctx.fill();
    ctx.closePath();
}

function drawScore() {
    ctx.beginPath();
    ctx.font = "30px Arial"
    ctx.fillStyle = "red";
    ctx.fillText("Score:" + score, 50, 50);
    ctx.closePath();
}

function draw() {
    ctx.clearRect(0, 0, canvas.width, canvas.height);
    drawBall();
    drawPaddle();
    drawScore();
}

function keyDown(e) {
    if (e.keyCode == 37) {
        leftPressed = true;
        rightPressed = false;
    }
    else if (e.keyCode == 39) {
        rightPressed = true;
        leftPressed = false;
    }
}

function keyUp(e) {
    if (e.keyCode == 37) {
        leftPressed = false;
    }
    else if (e.keyCode == 39) {
        rightPressed = false;
    }
}

function Update() {
    draw();
    movePaddle();
    x += dx;
    y += dy;
    ballCollition();
}

function startGame() {
    active = setInterval(Update, 10);
    document.getElementById("startBtn").style.visibility = "hidden";
}
