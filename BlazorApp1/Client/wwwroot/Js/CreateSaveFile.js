function createSaveFile(blob) {
    //var au = document.createElement("audio");
    let au = document.querySelector("audio");

    wav = window.URL.createObjectURL(blob);
    au.src = window.URL.createObjectURL(blob);
    let filename = new Date().toISOString().replaceAll(":", "");
    let fd = new FormData();
    fd.append("file", blob, filename);
    let xhr = new XMLHttpRequest();
    xhr.addEventListener("load", transferComplete);
    xhr.addEventListener("error", transferFailed);
    xhr.addEventListener("abort", transferFailed);
    xhr.open("POST", "api/Components/AudioSave/Save/", true);
    xhr.send(fd); //it fails her post 500 error
}

function transferComplete(evt) {
    console.log("The transfer is complete.");
}

function transferFailed(evt) {
    console.log("An error occurred while transferring the file.");

    console.log(evt.responseText);
    console.log(evt.status);
}