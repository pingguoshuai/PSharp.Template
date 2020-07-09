export function formatDate(time) {
  var time= time;
		
	var d = new Date(time);
		
  var times=d.getFullYear() + '-' + (d.getMonth() + 1) + '-' + d.getDate() + ' ' + d.getHours() + ':' + d.getMinutes() + ':' + d.getSeconds();
  
  return times
}