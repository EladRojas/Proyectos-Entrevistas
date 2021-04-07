function openRing(a) {
	var costoTotal = 0;
	var costoAbrir = 20;
	var costoCerrar = 35;

	for (var i = 1; i < a; ++i) {
		costoTotal += joinRings(costoAbrir,costoCerrar);
	}
	return costoTotal;
}

function joinRings(a,b){
	return a + b;
}