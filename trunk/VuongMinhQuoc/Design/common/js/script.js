// JavaScript Document
$(document).ready(function() {
$('body').append('<div id="top">Back to Top</div>');
$('#top').hide();
           $(window).scroll(function() {
            if($(window).scrollTop() != 0) {
                $('#top').fadeIn();
            } else {
                $('#top').fadeOut();
            }
           });
           $('#top').click(function() {
            $('html, body').animate({scrollTop:0},500);
   });
       // Call & Apply function scrollTo
    $('a.scrollTo').click(function () {
        $('body').scrollTo($(this).attr('href'), 800);
        return false;
	});
	$('#top').hide();
	
});


