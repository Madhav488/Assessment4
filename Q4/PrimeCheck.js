function isPrime(num) {
    if (num <= 1) {
        return false; // numbers <= 1 are not prime
    }
    for (let i = 2; i <= Math.sqrt(num); i++) {
        if (num % i === 0) {
            return false; // divisible by a number other than 1 and itself
        }
    }
    return true;
}

function checkNumber() {
    let number = parseInt(document.getElementById("numberInput").value);
    let resultElement = document.getElementById("result");

    if (isNaN(number)) {
        resultElement.textContent = "Please enter a valid number.";
        return;
    }

    if (isPrime(number)) {
        resultElement.textContent = number + " is a prime number.";
    } else {
        resultElement.textContent = number + " is not a prime number.";
    }
}
