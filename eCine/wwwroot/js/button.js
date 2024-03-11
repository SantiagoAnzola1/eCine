const btnBuy = document.querySelectorAll('#btn');
btnBuy.forEach((btn) => {
    btn.addEventListener('click', () => {

        btn.classList.add('active');
        setTimeout(() => {
            btn.classList.remove('active');
            btn.classList.add('reset');
        }, 1000);
        btn.classList.remove('reset');
    });
});


//Sinopsis


SinopsisToggle.addEventListener('click', () => {
    sinopsistoggleInfo.classList.toggle('hidden');

    const isVisible = !sinopsistoggleInfo.classList.contains('hidden');
    SinopsisToggle.querySelector('i').className = isVisible ? 'fas fa-caret-up' : 'fas fa-caret-down';

});

