function carregarHome(numeroRA) {
	var url = serviceBaseUrl + 'localizarAluno/ConsultarAluno';
	if (numeroRA) {
		url = url + '?numeroRA=' + numeroRA;
	}
	$('#homeLi').addClass('active');
	$('#historicoLi').removeClass('active');
	$('#containerPrincipal').load(url);
}

function carregarHistoricoConsultas() {
	var url = serviceBaseUrl + 'localizarAluno/ListarConsultas';
	$('#homeLi').removeClass('active');
	$('#historicoLi').addClass('active');
	$('#containerPrincipal').load(url);
}