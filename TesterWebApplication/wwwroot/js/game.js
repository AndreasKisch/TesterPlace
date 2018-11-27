//Game Test

var canvas = document.getElementById("gameArea");
var ctx = canvas.getContext("2d");

var score = 0;
var active;

document.addEventListener("keydown", keyDown, false);
document.addEventListener("keyup", keyUp, false);



//paddle rendered in canvas
var myPaddle;
//function to allow the creation of paddles with relevent vars and functions
function paddleObject(x, width, height, clr) {
    this.xPos = x;
    this.pWidth = width;
    this.pHeight = height;
    this.pSpeed = 0;
    this.colour = clr;

    this.move = function () {
        this.xPos += this.pSpeed;
    }

    this.changeSpeed = function (speed) {
        this.pSpeed = speed;
    }

    this.colltion = function () {
        if (this.xPos > canvas.width - this.pWidth && this.pSpeed > 0) {
            this.xPos = canvas.width - this.pWidth;
        }
        else if (this.xPos < 0 && this.pSpeed < 0) {
            this.xPos = 0;
        }
    }

    this.draw = function (ctx) {
        ctx.beginPath();
        ctx.rect(this.xPos, canvas.height - this.pHeight, this.pWidth, this.pHeight);
        ctx.fillStyle = this.colour;
        ctx.fill();
        ctx.closePath();
    }
}

//ball rendered in canvas
var ball;
//function to create balls containing relevent vars and functions
function ballObj(x, y, radius, clr) {
    this.xPos = x;
    this.yPos = y;
    this.ballRadius = radius;
    this.xVel = 2;
    this.yVel = -2;
    this.colour = clr;
    this.draw = function (ctx) {
        ctx.beginPath();
        ctx.arc(this.xPos, this.yPos, this.ballRadius, 0, Math.PI * 2);
        ctx.fillStyle = this.colour;
        ctx.fill();
        ctx.closePath();
    }

    this.move = function () {
        this.xPos += this.xVel;
        this.yPos += this.yVel;
    }

    this.colltion = function (paddle) {
        if (this.xPos + this.xVel > canvas.width - this.ballRadius || this.xPos + this.xVel < this.ballRadius) {
            this.xVel = -this.xVel;
        }
        if (this.yPos + this.yVel < this.ballRadius) {
            this.yVel = -this.yVel;
        }
        else if (this.yPos + this.yVel > canvas.height - (this.ballRadius / 2)) {
            if (this.xPos > paddle.xPos && this.xPos < (paddle.xPos + paddle.pWidth)) {
                this.yVel = -this.yVel;
                ++score;
            }
            else {
                gameOver();
            }
        }
    }

}


function keyDown(e) {
    if (e.keyCode == 37) {
        myPaddle.changeSpeed(-3);
    }
    else if (e.keyCode == 39) {
        myPaddle.changeSpeed(3);

    }
}

function keyUp(e) {
    if (e.keyCode == 37) {
        myPaddle.changeSpeed(0);
    }
    else if (e.keyCode == 39) {
        myPaddle.changeSpeed(0);
    }
}


function Update() {
    myPaddle.move();
    myPaddle.colltion();
    ball.move();
    ball.colltion(myPaddle);
    draw();
}

function draw() {
    ctx.clearRect(0, 0, canvas.width, canvas.height);
    ball.draw(ctx);
    myPaddle.draw(ctx);
    ctx.font = "15px Comic Sans MS";
    ctx.fillStyle = "pink";
    ctx.fillText("Score: " + score, 5, 15);
}

function startGame() {
    active = setInterval(Update, 10);
    document.getElementById("startBtn").style.visibility = "hidden";
    ball = new ballObj(canvas.width / 2, canvas.height - 30, 10, "orange")
    myPaddle = new paddleObject(canvas.width / 2, 75, 10, "black");
}

function gameOver() {
    clearInterval(active);
    document.getElementById("startBtn").style.visibility = "visible";
}