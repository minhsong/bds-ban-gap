//bullet at bottom footer
$(function() {
		$('#bottom_menu li').prepend('<span class="bullet">+</span>');
	})
//rounded	

$(function() {
		$('.rounded_box').prepend('<div class="TL"></div><div class="TR"></div><div class="BL"></div><div class="BR"></div>');
	})


//form
$('document').ready(function() {
	$('.form_style_1 input[type="text"]').wrap('<div class="wrap_input"></div>');
	$('.wrap_input').prepend('<span class="left"></span>');
	$('.wrap_input').append('<span class="right"></span>');
	$('.wrap_input').addClass("border_input");
	$('.form_style_1 .form_style_4').removeClass('wrap_input');
	$('.propertise_type .wrap_input:last').addClass("last");

//	$('.form_style_1 select').wrap('<div class="wrap_input"></div>');
//	$('.wrap_input').prepend('<span class="left"></span>');
})

//Tab Reality News
$(function (){
	$(".tab_container .tab_content").hide();
	$(".tab_container .tab_content:first").show();
	
	$("ul.tabs li").click(function(){
		$("ul.tabs li").removeClass('active');
		$(this).addClass("active");
		$(".tab_container .tab_content").hide();
		var activeTab = $("ul.tabs li a").attr("rel");
		$("#"+ activeTab).fadeIn();
	});

});

//Tab Reality News
$(document).ready(function(){
	$(".tab_container .tab_content").hide();
	$(".tab_container .tab_content:first").show();

});
	
		
//accordion menu for business page
$(function(){
	$('.infor_descript ul li:first .text ').show(); 
	$('.infor_descript > ul > li > a').click(function(){
		if ($(this).attr('class') != 'active') {
			$('.infor_descript ul li .text').slideUp();
			$(this).next().slideToggle();
			$('.infor_descript ul li a').removeClass('active');
			$(this).addClass('active');
			}
		});
	});
	

	
//Video slider
$.fn.infiniteCarousel = function () {

    function repeat(str, num) {
        return new Array( num + 1 ).join( str );
    }
  
    return this.each(function () {
        var $wrapper = $('> div', this).css('overflow', 'hidden'),
            $slider = $wrapper.find('> ul'),
            $items = $slider.find('> li'),
            $single = $items.filter(':first'),
            singleWidth = $single.outerWidth(), 
            visible = Math.ceil($wrapper.innerWidth() / singleWidth), // note: doesn't include padding or border
            currentPage = 1,
            pages = Math.ceil($items.length / visible);            


        // 1. Pad so that 'visible' number will always be seen, otherwise create empty items
        if (($items.length % visible) != 0) {
            $slider.append(repeat('<li class="empty" />', visible - ($items.length % visible)));
            $items = $slider.find('> li');
        }

        // 2. Top and tail the list with 'visible' number of items, top has the last section, and tail has the first
        $items.filter(':first').before($items.slice(- visible).clone().addClass('cloned'));
        $items.filter(':last').after($items.slice(0, visible).clone().addClass('cloned'));
        $items = $slider.find('> li'); // reselect
        
        // 3. Set the left position to the first 'real' item
        $wrapper.scrollLeft(singleWidth * visible);
        
        // 4. paging function
        function gotoPage(page) {
            var dir = page < currentPage ? -1 : 1,
                n = Math.abs(currentPage - page),
                left = singleWidth * dir * visible * n;
            
            $wrapper.filter(':not(:animated)').animate({
                scrollLeft : '+=' + left
            }, 500, function () {
                if (page == 0) {
                    $wrapper.scrollLeft(singleWidth * visible * pages);
                    page = pages;
                } else if (page > pages) {
                    $wrapper.scrollLeft(singleWidth * visible);
                    // reset back to start position
                    page = 1;
                } 

                currentPage = page;
            });                
            
            return false;
        }
        
        $wrapper.after('<a class="slider_control back"></a><a class="slider_control forward"></a>');
        
        // 5. Bind to the forward and back buttons
        $('a.back', this).click(function () {
            return gotoPage(currentPage - 1);                
        });
        
        $('a.forward', this).click(function () {
            return gotoPage(currentPage + 1);
        });
        
        // create a public interface to move to a specific page
        $(this).bind('goto', function (event, page) {
            gotoPage(page);
        });
    });  
};

$(document).ready(function () {
  $('.infiniteCarousel').infiniteCarousel();
});	

//slider for sieuthi_chitiet nhadep_chitiet
$(function() {
	$("#image_scroll li.img a").click(function(){
		var image = $(this).attr("rel");
		$("#show_image").hide();
		$("#show_image").fadeIn('slow');
		$("#show_image").html('<img src="' + image +'"/>');
		return false;
	});
});		


//Account Dropdown top head
//        $(document).ready(function() {
//            $("#head_content #acc_section .login a.signin").click(function(e) {          
//				e.preventDefault();
//                $("#dropdown_menu").toggle();
//				$("#head_content #acc_section .login a.signin").toggleClass("menu-open");
//            });
//			
//			$("#dropdown_menu").mouseup(function() {
//				return false
//			});
//			$(document).mouseup(function(e) {
//				if($(e.target).parent("#head_content #acc_section .login a.signin").length==0) {
//					$("#head_content #acc_section .login a.signin").removeClass("menu-open");
//					$("#dropdown_menu").hide();
//				}
//			});			
//			
//        });		
//		



