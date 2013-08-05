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

    $('ul.listImage li a').click(function() {
		var $this = $(this);
		if (!($this.hasClass('selected'))){
			$this.parents('ul.listImage').find('li a.selected').removeClass('selected');
			$this.addClass('selected');
			var $newImg = $this.parents('ul.listImage').find('li a.selected img').attr('src');
			//$('.box_Img img').attr('src', $newImg);
			$('.imgBig img.imgtop').fadeOut(400, function() {
				$(this).attr('src', $newImg).load(function() {
					$(this).fadeIn(400);
				});
			});
		}
		return false;
	});
	
	if (navigator.userAgent.match(/Android/i) ||
		navigator.userAgent.match(/webOS/i) ||
		navigator.userAgent.match(/iPhone/i) ||
		navigator.userAgent.match(/iPad/i) ||
		navigator.userAgent.match(/iPod/i) ||
		navigator.userAgent.match(/BlackBerry/) || 
		navigator.userAgent.match(/Windows Phone/i) || 
		navigator.userAgent.match(/ZuneWP7/i)
		) {
			$(".importPC").attr("href","common/css/importsp.css");
			$(".stylePC").attr("href","css/stylesp.css");
	}
});


