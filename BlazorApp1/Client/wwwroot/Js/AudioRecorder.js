window.AudioContext = window.AudioContext || window.webkitAudioContext;
navigator.getUserMedia = navigator.getUserMedia || navigator.webkitGetUserMedia || navigator.mozGetUserMedia || navigator.msGetUserMedia;

let audioCtx;

// This function visualizes the audio stream coming out of the user's microphone.
// Credit: Soledad Penades of https://soledadpenades.com/ via https://mdn.github.io/web-dictaphone/
function visualize(stream, canvas, canvasCtx) {
    if (!audioCtx) {
        audioCtx = new AudioContext();
    }

    const source = audioCtx.createMediaStreamSource(stream);

    const analyzer = audioCtx.createAnalyser();
    analyzer.fftSize = 2048;
    const bufferLength = analyzer.frequencyBinCount;
    const dataArray = new Uint8Array(bufferLength);

    source.connect(analyzer);
    //analyser.connect(audioCtx.destination);

    //draw();

    //function draw() {
    //    const WIDTH = canvas.width;
    //    const HEIGHT = canvas.height;

    //    requestAnimationFrame(draw);

    //    analyzer.getByteTimeDomainData(dataArray);

    //    canvasCtx.fillStyle = "rgb(200, 200, 200)";
    //    canvasCtx.fillRect(0, 0, WIDTH, HEIGHT);

    //    canvasCtx.lineWidth = 2;
    //    canvasCtx.strokeStyle = "rgb(0, 0, 0)";

    //    canvasCtx.beginPath();

    //    let sliceWidth = WIDTH * 1.0 / bufferLength;
    //    let x = 0;


    //    for (let i = 0; i < bufferLength; i++) {

    //        let v = dataArray[i] / 128.0;
    //        let y = v * HEIGHT / 2;

    //        if (i === 0) {
    //            canvasCtx.moveTo(x, y);
    //        } else {
    //            canvasCtx.lineTo(x, y);
    //        }

    //        x += sliceWidth;
    //    }

    //    canvasCtx.lineTo(canvas.width, canvas.height / 2);
    //    canvasCtx.stroke();

    //}
}

window.MyJSMethods = {

    startRecording: function () {
        navigator.getUserMedia({ audio: true }, onSuccess, onError);
    },

    stopRecording: function (element) {
        stop.click();
    }
};


let onError = function (err) {
    console.log(`The following error occurred: ${err}`);
};


let stop = document.querySelector(".stop");

let onSuccess = function (stream) {
    let audio = document.querySelector("audio");
    stop.disabled = false;

    let mainSection = document.querySelector(".main-controls");
    const canvas = document.querySelector(".visualizer");
    canvas.width = mainSection.offsetWidth;

    const canvasCtx = canvas.getContext("2d");

    let context = new AudioContext();
    let mediaStreamSource = context.createMediaStreamSource(stream);
    let recorder = new Recorder(mediaStreamSource);
    recorder.record();

    visualize(stream, canvas, canvasCtx);


    stop.onclick = function () {
        recorder.stop();

        recorder.exportWAV(function (s) {
            wav = window.URL.createObjectURL(s);
            audio.src = window.URL.createObjectURL(s);
            let filename = new Date().toISOString().replaceAll(":", "");
            let fd = new FormData();
            fd.append("file", s, filename);
            let xhr = new XMLHttpRequest();
            xhr.addEventListener("load", transferComplete);
            xhr.addEventListener("error", transferFailed);
            xhr.addEventListener("abort", transferFailed);
            xhr.open("POST", "api/SaveAudio/Save/", true);
            xhr.send(fd);

        });

        stop.disabled = true;
        function transferComplete(evt) {
            console.log("The transfer is complete.");
            //GLOBAL.DotNetReference.invokeMethodAsync('Recognize', filename);

        }

        function transferFailed(evt) {
            console.log("An error occurred while transferring the file.");

            console.log(evt.responseText);
            console.log(evt.status);
        }

    };
};