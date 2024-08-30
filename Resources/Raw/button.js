document.addEventListener('DOMContentLoaded', function () {
    let button = document.querySelector('.button');
    let buttonText = document.querySelector('.tick');

    const tickMark = "<svg width=\"16\" height=\"16\" viewBox=\"0 0 58 45\" xmlns=\"http://www.w3.org/2000/svg\"><path fill=\"#fff\" fill-rule=\"nonzero\" d=\"M19.11 44.64L.27 25.81l5.66-5.66 13.18 13.18L52.07.38l5.65 5.65\"/></svg>";

    buttonText.innerHTML = "Se connecter"; // Default text

    button.addEventListener('click', function () {
        if (button.classList.contains('active')) {
            buttonText.innerHTML = "Se connecter";
            button.classList.remove('active');
        } else {
            buttonText.innerHTML = tickMark;
            button.classList.add('active');

            // Trigger navigation if needed (example)
            // window.location.href = 'mauiapp:login'; // Uncomment if using custom URL scheme
        }
    });
});
