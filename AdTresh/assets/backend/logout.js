$(document).ready(function () {
    // starts the logout view 
    const _session = sessionStorage.clear();
    if(_session === '' || _session === null || _session === undefined){
        window.location.href='./login.html';
    }

});