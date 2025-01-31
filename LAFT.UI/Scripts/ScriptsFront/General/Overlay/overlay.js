var checkboxSound = new Howl({
    src: ['https://systemspace.network/assets/audio/button-click-small.ogg'],
    volume: 0.5,
    loop: false,
    preload: true
});

var destroy = new Howl({
    src: ['https://systemspace.network/assets/audio/destroy.ogg'],
    volume: 1,
    loop: false,
    preload: true
});



$(document).ready(() => {
    $(".url").html(window.location.hostname);

    const $checkbox = $('#agreement-checkbox');
    const $agreeButton = $('#agree-button');
    const $dialogueBox = $('.dialogue');

    const currentURL = window.location.hostname;

    const cookieValue = getCookie('visitedURLs');

    let visitedURLs = cookieValue ? JSON.parse(cookieValue) : [];

    if (visitedURLs.includes(currentURL)) {
        $("#overlay-wrapper").remove();
        return;
    }

    const viewportWidth = window.innerWidth;
    const viewportHeight = window.innerHeight;

    const element = $dialogueBox;
    const elementWidth = element[0].offsetWidth;
    const elementHeight = element[0].offsetHeight;

    const maxScaleX = viewportWidth / elementWidth;
    const maxScaleY = viewportHeight / elementHeight;

    const maxScale = Math.min(maxScaleX, maxScaleY);

    if (viewportWidth >= 600 && viewportHeight >= 400) {
        element.css('transform', `scale(${Math.min(1.2, maxScale)})`);
    } else {
        element.css('transform', 'scale(1)');
    }

    $checkbox.on('change', function () {
        checkboxSound.play();

        if (this.checked) {
            $agreeButton.prop('disabled', false);

            $dialogueBox.addClass('push-in');
            $(".dialogue").addClass('shake-slowly');
            $('.hexagon-checkbox').addClass('sizebuddy');

            setTimeout(() => {
                $('.hexagon-checkbox').removeClass('sizebuddy');
                $dialogueBox.removeClass('push-in');
            }, 500);
        } else {
            $(".dialogue").removeClass('shake-slowly');
            $agreeButton.prop('disabled', true);
        }
    });
});

function goForward() {
    destroy.play();

    const currentURL = window.location.hostname;

    const cookieValue = getCookie('visitedURLs');
    let visitedURLs = cookieValue ? JSON.parse(cookieValue) : [];

    if (!visitedURLs.includes(currentURL)) {
        visitedURLs.push(currentURL);
    }

    const expires = new Date();

    expires.setFullYear(expires.getFullYear() + 1);

    document.cookie = `visitedURLs=${JSON.stringify(visitedURLs)}; expires=${expires.toUTCString()}; path=/`;

    $("#overlay-wrapper").fadeOut(2000);

    setTimeout(() => {
        $("#overlay-wrapper").remove();
    }, 2000);
}