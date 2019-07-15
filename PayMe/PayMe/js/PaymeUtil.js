function GetHoursDiffernace(dtfrom , dtTo) {
    var dtf = new Date(dtfrom);
    var dtt = new Date(dtTo);
   
    var sec_num = (dtf - dtt) / 1000;
    var days    = Math.floor(sec_num / (3600 * 24));
    var hours   = Math.floor((sec_num - (days * (3600 * 24)))/3600);
    var minutes = Math.floor((sec_num - (days * (3600 * 24)) - (hours * 3600)) / 60);
    var seconds = Math.floor(sec_num - (days * (3600 * 24)) - (hours * 3600) - (minutes * 60));

    if (hours   < 10) {hours   = "0"+hours;}
    if (minutes < 10) {minutes = "0"+minutes;}
    if (seconds < 10) {seconds = "0"+seconds;}

    return  days+':'+ hours+':'+minutes+':'+seconds;
}