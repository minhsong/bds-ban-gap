//show hide tab
$(function () {
    $('#tablastnews').click(function () {
        $(this).addClass('actived');
        $(this).html('<span class="L"></span><a href="javascript:void(0)">' + $(this).text() + '</a><span class="R"></span>')
        $('#lastnews').attr('style', 'display:block');
        $('#tabtopnews').removeClass('actived');
        $('#tabtopnews').html('<a href="javascript:void(0)"><span>' + $('#tabtopnews').text() + '</span></a>')
        $('#topnews').attr('style', 'display:none');
    });
    $('#tabtopnews').click(function () {
        $('#tablastnews').removeClass('actived');
        $('#tablastnews').html('<span class="L"></span><a href="javascript:void(0)"><span>' + $('#tablastnews').text() + '</span></a><span class="R"></span>')
        $('#lastnews').attr('style', 'display:none');
        $(this).addClass('actived');
        $(this).html('<span class="L"></span><a href="javascript:void(0)">' + $(this).text() + '</a><span class="R"></span>')
        $('#topnews').attr('style', 'display:block');
    });

    

    $('#CityList').change(function () {
        GetData('District', '_DistrictByCityId', $(this).val(), '#district');
        $('#ward').find('option').remove();
        $('#street').find('option').remove();
    });
    $("#district").delegate('#DistrictList', 'change', function (e) {
        GetData('Ward', '_WardByDistrictId', $(this).val(), '#ward');
        GetData('Street', '_StreetByDistrictId', $(this).val(), '#street');
    });

    $('#QuickCityList').change(function () {
        GetData('District', '_QuickDistrictByCityId', $(this).val(), '#quickdistrict');
        $('#QuickProjectList').find('option[value!="-1"]').remove();
    });
    $("#quickdistrict").delegate('#QuickDistrictList', 'change', function (e) {
        var queryProject = $(this).val() + '?tp=' + $("#QuickCityList").val() + '&qh=' + $("#QuickDistrictList").val();
        GetData("Project", "_QuickProjectByCityDistrict", queryProject, "#quickproject");
    });

    $('#CityListMember').change(function () {
        GetData('District', '_DistrictByCityIdMember', $(this).val(), '#districtMember');
        $('#WardListMember').find('option[value!=""]').remove();
        $('#StreetListMember').find('option[value!=""]').remove();
        $('#ProjectListMember').find('option[value!=""]').remove();
    });

    $("#districtMember").delegate('#DistrictListMember', 'change', function (e) {
        GetData("Ward", "_WardByDistrictIdMember", $(this).val(), "#wardMember");
        GetData("Street", "_StreetByDistrictIdMember", $(this).val(), "#streetMember");
        var queryProject = $(this).val() + '?did=' + $("#DistrictListMember").val() + '&cid=' + $("#CityListMember").val();
        GetData("Project", "_ProjectByCityIdDistrictIdMember", queryProject, "#projectMember");
    });

    // submit form
    $('#SearchSubmit').click(function () {
        BuildUrl();
    });

    $('#frmSearch').keyup(function (event) {
        var key = event.keyCode || event.which;
        if (key === 13) {
            BuildUrl();
            return true;
        }
    });

    // Ẩn/ hiện serial input trong chức năng nạp điểm dool
    $('#ServiceList').change(function () {
        var ddlSupplier = $(this).val();
        if (ddlSupplier == 'VTT' || ddlSupplier == 'VTC' || ddlSupplier == 'FPT'
            || ddlSupplier == 'VNP' || ddlSupplier == 'VMS') {
            $('#serial_info').fadeIn(800);
        }
        else {
            $('#serial_info').fadeOut(800);
        }
    });

    // Validation chỉ cho phép nhập số
    $('.keypress').keypress(function (e) {
        var keypressed = null;
        if (window.event) {
            keypressed = window.event.keyCode; //IE
        }
        else {
            keypressed = e.which; //NON-IE, Standard
        }
        if (keypressed < 48 || keypressed > 57) {
            if (keypressed == 8) {
                return;
            }
            if (keypressed == 127) {
                return;
            }
            return false;
        }
    });

})

function DeleteItem(urlData, idRemove, conf) {
    if (conf == true)
    {
        if (!confirm("Bạn chắc chắn muốn xóa thông tin này ?")) 
        {
            conf = false;
        }
    }else{
        conf = true;
    }
    if(conf == true)
    {
        $.ajax({
            type: "POST"
            , url: urlData
            , cache: false
            , dataType: "json"
            , success: function (data) {
                if (data != null & data != "") {
                    if (data.message == true) {
                        $("#" + idRemove).fadeOut(600);
                        setTimeout(function(){
                            $("#" + idRemove).remove()
                        },600);
                    } 
                }
            }
        });
    }
}


function LoadPagging(pi, ps, url, urlext) {
    var sep = '/';
    if (url.indexOf('?') > 0) {
        sep = '&pi=';
        if(url.indexOf(sep) > 0)
        {
            url = url.substring(0, url.indexOf(sep));
        }
    }
    
    var content = '';
    var offset = 5;
    var offhalf = 2;
    var pos = pi - 1; // position in array

    if (ps <= 1 || pi < 1 || pi > ps) {
        return false;
    }
    // array
            
    // ps > 1
    // previous
    if (pi == 1) {
        content += '<li><a href="javascript:void(0)" style="cursor:default;">&laquo;</a></li>';
    } else {
        if (pi == 2) {
            content += '<li class="back"><a rel="prev" href="' + url + '">&laquo;</a></li>';
        } else {
            content += '<li class="back"><a rel="prev" href="' + url + sep + (pi - 1) + '">&laquo;</a></li>';
        }
    }

    // Length Pagging
    var from = 1;
    var to = offset;

    if(ps <= offset)
    {
        to = ps;
    }else if(ps > offset)
    {
        var left = pi - offhalf;
        var right = pi + offhalf;
                
        if(left < 1)
        {
            from = 1;
            to = offset;
        }else if(right > ps)
        {
            to = ps;
            from = ps - offset + 1; 
        }else
        {
            from = left;
            to = right;
        }
    }

    for (var i = from; i <= to; i++) {
        var activeLi = '';
        var active = '';
        if(pi == i)
        {
            content += '<li class="actived"><a href="javascript:void(0)" >' + i + '</a></li>';
        } else {
            var rel = ' rel="next" ';
            if (i < pi)
            {
                rel = ' rel="prev" ';
            }
            if (i == 1) {
                content += '<li><a href="' + url + '" ' + active + ' ' + rel + '>' + i + '</a></li>';
            }else
            {
                content += '<li><a href="' + url + sep + i + '" ' + active + ' ' + rel + '>' + i + '</a></li>';
            }
        }
    }

    // Next
    if(pi == ps)
    {
        content += '<li><a rel="next" href="javascript:void(0)" style="cursor:default;">&raquo;</a></li>';
    }else
    {
        content += '<li class="forward"><a rel="next" href="' + url + sep + (pi + 1) + '">&raquo;</a></li>';
    }
    return content;
}

function PostComment(tid, id) {
    // validate
    var fullName = $('#FullName').val();
    var email = $('#Email').val();
    var title = $('#Title').val();
    var codeConfirm = $('#CodeConfirm').val();
    var message = $('#Message').val();
    // chưa validate js
    if (fullName.length < 3) {
        $('#error-message').fadeIn('slow');
        $('#error-message').html("» Tên của bạn có ít nhất 3 kí tự.");
        $('#FullName').focus();
        return;
    }
    if (email.length < 5 ) {
        $('#error-message').fadeIn('slow');
        $('#error-message').html("» Email không hợp lệ.");
        $('#Email').focus();
        return;
    }
    if (message.length < 50 || message.length > 1000) {
        $('#error-message').fadeIn('slow');
        $('#error-message').html("» Nội dung có từ 50 đến 1000 kí tự.");
        $('#Message').focus();
        return;
    }

    $.ajax({
        type: 'POST',
        url: '/gui-binh-luan',
        data: { tid: tid
                , id: id
                , fn: fullName
                , em: email
                , tt: title
                , cc: codeConfirm
                , mg: message
        },
        // contentType: 'application/json; charset=utf-8',
        dataType: "json",
        beforeSend: function () {
            $('#cloader').html('<img src="/Content/loading.gif"/>');
        },
        complete: function () {
            $('#cloader').html('');
        },
        error: function () { alert("Có lỗi xảy ra. Vui lòng chờ trong giây lát") },
        success: function (data) {
            if (data != null) {
                if (data.flag == true) {
                    $('#frmComment ul').remove();
                }
                if (data.code == '1.1') {
                    $('#FullName').focus();
                } else if (data.code == '1.2') {
                    $('#Email').focus();
                } else if (data.code == '1.3') {
                    $('#Message').focus();
                } 
                $('#error-message').fadeIn(900);
                $('#error-message').text("» " + data.msg);
            }
        }
    });
}
function GetData(controller, action, id, idData) {
    $.ajax({
        type: "GET"
        , url: "/" + controller + "/" + action + "/" + id
        , cache: false
        , dataType: "html"
        , success: function (data) {
            if (data != null & data != "") {
                $(idData).html(data);
            }
        }
    });
}
function GetDataConfirm(urlData, idData) {
    if (confirm('Bạn xác nhận ngừng đăng tài sản này?')) {
        $.ajax({
            type: "POST"
            , url: urlData
            , cache: false
            , dataType: "json"
            , success: function (data) {
                if (data != null & data.msg == true) {
                    $('#' + idData).fadeOut(600);
                }
            }
        });
    }
}
function GetReactive(url, ida) {
    $.ajax({
        type: "POST"
        , url: url
        , cache: false
        , dataType: "json"
        , success: function (data) {
            if (data != null & data.msg == true) {
                $('#UserPoint').fadeOut(400);
                setTimeout(function () {
                    $('#UserPoint').fadeIn(400);
                    $('#UserPoint').text(data.upoint);
                }, 400);
                if (data.isdel == false) {
                    $('#khl_' + ida).fadeOut(400);
                    $('#pub_' + ida).fadeOut(400);
                    $('#exp_' + ida).fadeOut(400);

                    setTimeout(function () {
                        $('#khl_' + ida).fadeIn(400);
                        $('#pub_' + ida).fadeIn(400);
                        $('#exp_' + ida).fadeIn(400);
                        $('#pub_' + ida).text(data.pub);
                        $('#exp_' + ida).text(data.exp);
                        $('#khl_' + ida).html('<a class="reactive-true">' + data.err + '</a>');
                    }, 400);

                }
                else {
                    alert(data.err);
                    $('#item_' + ida).fadeOut(500);
                    setTimeout(function () {
                        $('#item_' + ida).remove();
                    }, 600);
                }
            } else {
                alert(data.err);
            }
        }
    });
}
//function GetDataSaved(urlData, urlReturn, idData) {
//    $.ajax({
//        type: "POST"
//        , url: urlData
//        , cache: false
//        , dataType: "json"
//        , success: function (data) {
//            if (data != null) {
//                if (data.msg == 'da-luu') {
//                    $(idData).fadeOut(500).fadeIn(600);
//                    setTimeout(function () {
//                        $(idData).html('<span class="ico_16 ico_save_2_16"></span> Tin đã lưu')
//                    }, 700);
//                    
//                } else if (data.msg == 'dang-nhap') {
//                    window.location = "/dang-nhap?ReturnUrl=" + urlReturn;
//                }
//            }
//        }
//    });
//}

function GetDataSaved(urlData, urlReturn, idData) {
    $.ajax({
        type: "POST"
        , url: "/luu-tin?k=" + urlData
        , cache: false
        , dataType: "json"
        , success: function (data) {
            if (data != null) {
                if (data.msg == 'da-luu') {
                    $(idData).fadeOut(500).fadeIn(600);
                    setTimeout(function () {
                        $(idData).html('<span class="ico_16 ico_save_2_16"></span> Tin đã lưu')
                    }, 700);
                    
                } else if (data.msg == 'dang-nhap') {
                    window.location = "/dang-nhap?ReturnUrl=" + urlReturn;
                }
            }
        }
    });
}


function DeleteDataSaved(urlData, urlReturn, idData) {
    $.ajax({
        type: "POST"
        , url: urlData
        , cache: false
        , dataType: "json"
        , success: function (data) {
            if (data != null) {
                if (data.msg == true) {
                    $(idData).fadeOut(600);
                    $(".ItemTotal").text(parseInt($(".ItemTotal").text()) - 1); 

                } else if (data.msg == 'dang-nhap') {
                    window.location = "/dang-nhap?ReturnUrl=" + urlReturn;
                }
            }
        }
    });
}

function BuildUrl() {
    var act = $('#frmSearch').attr('action');
    var url = '';
    $('[param]').each(function () {
        var name = $(this).attr('param').trim();
        var valParam = $(this).val().trim();
        if (url.indexOf(name) < 0 && valParam != '') {
            url += name + '=' + valParam + '&';
        }
    });
    if (url.length > 0) {
        // remove kí tự & cuối
        url = url.substring(0, url.length - 1);
    }
    if (url.length != 0 ) {
        window.location = act + "/?" + url;
    }else 
    {
        window.location = act;
    }
}

function PostSurvey(qId, mc) {
    if (mc == 'True') {

        var name = "chk_" + qId;
        var arrId = '';
        var selected = $('input:checkbox[name=' + name + ']:checked').val();
        if (!selected) {
            alert("Vui lòng chọn câu trả lời.");
            return;
        }
        else {
            $('input:checkbox[name=' + name + ']:checked').each(function () {
                if (arrId == "") {
                    arrId = $(this).val();
                }
                else {
                    arrId += ',' + $(this).val();
                }
            });
        }
    }
    else {
        var radname = "radio_" + qId;
        var selected = $('input:radio[name=' + radname + ']:checked').val();
        if (!selected) {
            alert("Vui lòng chọn câu trả lời.");
            return;
        }
        else {
            arrId = selected;
        }
    }

    $.ajax({
        type: "POST"
        , url: '/gui-bieu-quyet'
        , data: { qid: qId
            , arr: arrId
        }
        , dataType: "json"
        , beforeSend: function () {
            $('#cloader').html('<img src="/Content/loading.gif"/>');
        }
        , complete: function () {
            $('#cloader').html('');
        }
        , error: function () { alert("Có lỗi xảy ra. Vui lòng chờ trong giây lát") }
        , success: function (data) {
            if (data != null) {
                $('input:checked').removeAttr('checked');
                $('#client-message').fadeIn(500);
                $('#client-message').text("» " + data.msg);

                setTimeout(function () {
                    $('#client-message').empty();
                    $('#client-message').fadeOut(500);
                }, 5000);
            }
        }
    });
}

function InsertConnect() {
    var ttc = $('#TenTruyCap').val();
    if(ttc.length < 3)
    {
        $('#TenTruyCap').focus();
        return false;
    }
    $.ajax({
        type: "POST"
        , url: $('#UrlSend').val()
        , cache: false
        , dataType: "json"
        , data: {
            TenTruyCap: ttc
        }
        , success: function (data) {
            if (data != null) {
                $('#error-message').text(data.err);
                $('#error-message').fadeIn(500);
                setTimeout(function () {
                    $('#error-message').empty();
                    $('#error-message').fadeOut(500);
                }, 5000);
                if (data.msg == true) {
                    $('#TenTruyCap').val('');
                    setTimeout(function () {
                        window.location = $('#UrlReturn').val();
                    }, 2000);
                }
                
            }
        }
    });
}
function StopConnect(u) {
    if (u.length < 3) {
        return false;
    }
    if (confirm('Bạn có muốn ngừng kết nối không?')) {
        $.ajax({
            type: "POST"
        , url: $('#LinkStop').val()
        , cache: false
        , dataType: "json"
        , data: {
            TenTruyCap: u
        }
        , success: function (data) {
            if (data != null) {
                $('#error-message').text(data.err);
                $('#error-message').fadeIn(500);
                setTimeout(function () {
                    $('#error-message').empty();
                    $('#error-message').fadeOut(500);
                }, 5000);
                if (data.msg == true) {
                    $('#' + u).fadeOut(500);
                    setTimeout(function () {
                        $('#' + u).remove();
                    }, 600);
                }
            }
        }
        });
    }
}
function GetStatistic(qid, status) 
{
    $('#fs_' + qid).fadeOut('slow', function () {
        if (status=='True') {
            $('#contentAws_' + qid).hide();
            $('#contentRvote_' + qid).show();
            $('#submit_' + qid).hide();
            $('#stc_' + qid).html(function () {
                var _scontent = '<span>TRỞ VỀ</span>';
                return _scontent;
            });
            status = "False";
        }
        else {
            $('#contentAws_' + qid).show();
            $('#contentRvote_' + qid).hide();
            $('#submit_' + qid).show();
            $('#stc_' + qid).html(function () {
                var _content = '<span>XEM KẾT QUẢ</span>';
                return _content;
            });
            status = "True";
        }
        $('#stc_' + qid).removeAttr("onclick");
        $('#stc_' + qid).attr("onclick","GetStatistic('"+ qid +"','"+ status +"')");

    }).fadeIn('slow');
}

