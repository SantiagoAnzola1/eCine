// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
// Initialization for ES Users

// Write your JavaScript code.


const navContainer = document.querySelector("#nav-container")
const searchField = document.querySelector("#search-field")
const searchSubmit = document.querySelector("#search-submit")
const cleanInput = document.querySelector("#clean-input")
const searchButton = document.querySelector("#search-button")
const SearchContainer = document.querySelector("#search-input-container")
const searchDesplazable = document.querySelector("#search-desplazable")
const menuDesplazable = document.querySelector("#menu-desplazable")
const navbar = document.querySelector("#navbar")
const onblur = document.querySelector("#blur-area")
const cancelBtn = document.querySelector("#cancel-btn")
const navItem = document.querySelectorAll(".nav-item-link")
const navBrand = document.querySelector("#navbar-logo")
const containerNav = document.querySelectorAll(".container-nav")
const navbarNav = document.querySelector("#navbar-nav")
const backBtn = document.querySelector("#back-btn")
const navIconItem = document.querySelectorAll(".icon-item")
const body = document.querySelector("body");
var isSearchInputFocused = false;
var isSearchButton = false;
let isHamburguer = false;
const dropdawn = document.querySelector("#dropdown-container")

const contenedorSVG = document.getElementById('contenedor-svg');

let svg = true;
const btn = document.querySelectorAll('#btn-buy');
btn.forEach((btn) => {
    btn.addEventListener('click', () => {

        btn.classList.add('active');
        setTimeout(() => {
            btn.classList.remove('active');
            btn.classList.add('reset');
        }, 1000);
        btn.classList.remove('reset');
    });
});




const masInformacion = document.querySelectorAll('#more-info-toggle');

masInformacion.forEach((masInfo, index) => {
    masInfo.addEventListener('click', () => {
        console.log("click");

        var toggleInfo = document.querySelectorAll('.toggle-info')[index];
        toggleInfo.classList.toggle('hidden');

        const isVisible = !toggleInfo.classList.contains('hidden');

        masInfo.querySelector('span').textContent = isVisible ? 'Hide' : 'More information';
        masInfo.querySelector('i').className = isVisible ? 'fas fa-caret-up' : 'fas fa-caret-down';

    });
});

const SinopsisToggle = document.querySelector('#sinopsis-toggle');
const sinopsistoggleInfo = document.querySelector('#toggle-sinopsis-info')

let formWidth
const multiselectContainer = document.getElementById('multiselect-container');
document.addEventListener('DOMContentLoaded', (event) => {
    if (multiselectContainer != null) {
        formWidth = document.getElementById('container-form-base-width').offsetWidth + 'px';
        multiselectContainer.style.width = formWidth;
    }
})
function onResize() {

    if (multiselectContainer != null) {
        formWidth = document.getElementById('container-form-base-width').offsetWidth + 'px'
        multiselectContainer.style.width = formWidth;

    }
    //console.log(multiselectContainer.offsetWidth)
    if (window.screen.width <= 410) {

        masInformacion.forEach((masInfo, index) => {
            var toggleInfo = document.querySelectorAll('.toggle-info')[index];
            const isHidden = toggleInfo.classList.contains('hidden');

            if (!isHidden) toggleInfo.classList.toggle('hidden');
            masInfo.querySelector('span').textContent = 'Más información';
            masInfo.querySelector('i').className = 'fas fa-caret-down';
        });

    }
    if (window.innerWidth > 575) {
        if (sinopsistoggleInfo != null) {

            sinopsistoggleInfo.classList.remove('hidden');
            SinopsisToggle.classList.add('hidden');
        }
        removeMenuHamburguesa()
    } else {
        if (sinopsistoggleInfo != null) {
            sinopsistoggleInfo.classList.add('hidden');
            SinopsisToggle.classList.remove('hidden');
        }
    }
}
onResize();
window.onresize = onResize;


//const isFocus=false;
function toggleSearchInput() {
    isSearchButton = !isSearchButton
    const isFocus = searchField.classList.contains('focus')
    searchField.classList.toggle('focus')
    //searchField.focus({ preventScroll: true })
    if (isFocus) {
        /*setTimeout(() => { searchField.setAttribute('placeholder', '') }, 150)*/
        //searchField.blur()
    } else {
        searchField.setAttribute('placeholder', 'Buscar')
    }
    SearchContainer.classList.toggle('focus')
    searchSubmit.classList.toggle('focus')
    //searchSubmit.classList.toggle('search-absolute');
    searchButton.classList.toggle('focus')
    cleanInput.classList.toggle('focus')
    searchDesplazable.classList.toggle('focus')
    onblur.classList.toggle('blur')
    navbar.classList.toggle('focus')
    cancelBtn.classList.toggle('focus')
    backBtn.classList.toggle('focus')
    navBrand.classList.toggle('focus')

    //containerNav.classList.toggle('focus')

    navItem.forEach((nav) => { nav.classList.toggle('search'); });

    containerNav.forEach((co) => { co.classList.toggle('focus'); });
    //searchField.focus({ preventScroll: true })

}
searchField.focus({ preventScroll: true })

searchButton.addEventListener('click', () => {
    //searchField.focus({ preventScroll: true })
    /*window.requestAnimationFrame(() => searchField.focus())*/
    focusInput()
    if (!isSearchButton) {
        SearchContainer.addEventListener('submit', function (event) {
            if (!isSearchButton) {
                event.preventDefault() // Prevent the form from submitting
                toggleSearchInput()
            }
        });


    }
    /*focusInput()*/
});
cleanInput.addEventListener('click', () => {

    searchField.value = ''
    searchField.focus({ preventScroll: true })

});
onblur.addEventListener('click', () => {
    toggleSearchInput()

});

function focusInput() {
    setTimeout(() => { searchField.focus({ preventScroll: true }) }, 150)
    console.log("focus")
}

function cambiarSVG(nombreSVG) {
    // Obtén el contenedor SVG

    // Cambia la opacidad a 0 para ocultar el SVG actual
    contenedorSVG.style.opacity = 0;
    contenedorSVG.style.transform = 'rotate(-30deg)';
    // Espera un breve período de tiempo antes de cambiar el contenido
    setTimeout(function () {
        // Cambia el contenido del contenedor SVG
        contenedorSVG.innerHTML = obtenerContenidoSVG(nombreSVG);

        // Restaura la opacidad a 1 para mostrar el nuevo SVG con animación
        contenedorSVG.style.opacity = 1;
        contenedorSVG.style.transform = 'rotate(30deg)';
    }, 200);
}

function obtenerContenidoSVG(nombreSVG) {
    // Definir los SVG según tus necesidades, similar al ejemplo anterior
    switch (nombreSVG) {
        case true:
            return '<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="#000000" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-menu"><line x1="3" y1="12" x2="21" y2="12"></line><line x1="3" y1="6" x2="21" y2="6"></line><line x1="3" y1="18" x2="21" y2="18"></line></svg>'
        case false:
            return '<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-x"><line x1="18" y1="6" x2="6" y2="18"></line><line x1="6" y1="6" x2="18" y2="18"></line></svg>'
        default:
            return 'svg1' // Devuelve una cadena vacía si no se encuentra el SVG
    }
}
function toggleMenuHamburguesa() {
    isHamburguer = !isHamburguer;
    menuDesplazable.classList.toggle('menu')
    navContainer.classList.toggle('menu')
    //containerNav.classList.toggle('menu')
    containerNav.forEach((co) => { co.classList.toggle('menu'); });
    navbarNav.classList.toggle('menu')
    navItem.forEach((nav) => { nav.classList.toggle('menu') })
    navIconItem.forEach((nav) => { nav.classList.toggle('d-none') })
    svg = !svg
    cambiarSVG(svg)
    body.classList.toggle('overflow-hidden')


    dropdawn?.classList.toggle('nav-link')

    //if (isHamburguer) {
    //    body.classList.()
    //}


}
function removeMenuHamburguesa() {

    menuDesplazable.classList.remove('menu')
    navContainer.classList.remove('menu')
    containerNav.forEach((co) => { co.classList.remove('menu'); });
    //containerNav.classList.remove('menu')
    navbarNav.classList.remove('menu')
    navItem.forEach((nav) => { nav.classList.remove('menu') })
    navIconItem.forEach((nav) => { nav.classList.remove('d-none') })
    body.classList.remove('overflow-hidden')
    dropdawn?.classList.remove('nav-link')
    svg = true;
    cambiarSVG(svg)
}

contenedorSVG.addEventListener('click', () => {
    toggleMenuHamburguesa()
});
// Cargar un SVG por defecto al cargar la página
cambiarSVG(svg);


//