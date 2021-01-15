$(document).ready(function(){
    // get the session details here 
    var _activeSession = sessionStorage.getItem('_activeUserId');
    if(_activeSession === null || _activeSession === '' || _activeSession === undefined){
        window.location.href='login.html';
    }else {
      // the code begins here 
      
      // get the count of transactions done 
    }
   // alert(_activeSession);
});