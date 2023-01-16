var play = document.getElementById("play");
var video = document.getElementsByTagName("video")[0];
var stop = document.getElementById("stop");
var mute = document.getElementById("mute");
var gofirst = document.getElementById("gofirst");
var backf = document.getElementById("backf");
var gof = document.getElementById("gof");
var goend = document.getElementById("goend");
var ptime = document.getElementById("timeduration");
var progressvolum = document.getElementById("progressvolum");
var speed = document.getElementById("speed-bar");
var full = document.getElementById("full");
var currentdu = document.getElementById("currentdu");
var totaldu = document.getElementById("totaldu");

video.ontimeupdate = function () {
  ptime.value = video.currentTime;

  var sec_num = parseInt(0 + video.currentTime);
  var hours = Math.floor(sec_num / 3600);
  var minutes = Math.floor((sec_num - hours * 3600) / 60);
  var seconds = sec_num - hours * 3600 - minutes * 60;

  currentdu.innerText = minutes + "." + seconds;

  totaldu.innerText =
    Math.floor(parseInt(video.duration) / 60) +
    "." +
    parseInt(video.duration - Math.floor(video.duration / 60) * 60);
};

play.addEventListener("click", function () {
  video.play();
});

full.onclick = function () {
  video.webkitEnterFullscreen();
};

stop.addEventListener("click", function () {
  video.pause();
});

mute.addEventListener("click", function () {
  video.muted = true;
});

gofirst.addEventListener("click", function () {
  video.currentTime = 0;
});

progressvolum.onchange = function () {
  video.volume = this.value;
};
speed.onchange = function () {
  video.playbackRate = this.value;
};

goend.addEventListener("click", function () {
  video.currentTime = video.duration;
});

backf.onclick = function () {
  video.currentTime -= 5;
};

gof.onclick = function () {
  video.currentTime += 5;
};
