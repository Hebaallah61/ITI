function InfoGuess() {
	alert("Hello from Calling C# function from javaScript))");
}

function NameAgainFun() {
    DotNet.invokeMethodAsync('task1', 'NameAgain')
        .then(result => {
            document.getElementById('NameID').innerText = result;
        })
        .catch(error => {
            console.error(error);
        });
}


