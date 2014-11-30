
function validarNumeroRa(raAlunoInputText) {
	if (raAlunoInputText.value == '') {
		raAlunoInputText.setCustomValidity('Digite o número de RA!');
	}
	else {
		raAlunoInputText.setCustomValidity('');
	}
	return true;
}

function submeterBuscaAluno() {
	var numeroRA = $('#raAlunoInputText').val();

	localizarAluno(numeroRA);
}

function localizarAluno(numeroRA) {

	$('#raAlunoInputText').val(numeroRA);

	condicaoNumeroRA = 'RA_Aluno=' + numeroRA;

	condicaoNumeroRA = encodeURIComponent(condicaoNumeroRA);

	var url = 'https://www.googleapis.com/mapsengine/v1/tables/16301484656389751053-01619059540675406410/features?where=' + condicaoNumeroRA + '&version=published&key=AIzaSyAsrcj7OColofVBkQHQOJDL0_dIQxGjyjY&limit=1';

	$.ajax({
		url: url,
		contentType: 'application/json; charset=utf-8',
		type: 'GET',
		complete: function (data) {
			dadosAluno = JSON.parse(data.responseText);
			if (dadosAluno.features.length == 1) {
				alunoEncontrado(dadosAluno);
			} else {
				alunoNaoEncontrado(numeroRA);
			}
		}
	})
}

function alunoNaoEncontrado(numeroRA) {

	registrarConsulta(numeroRA, false)

	mensagemInformação('Aluno não encontrado!');
}

function alunoEncontrado(dadosAluno) {

	var coordenadas = dadosAluno.features[0].geometry.coordinates;
	var informacoes = dadosAluno.features[0].properties;
	var texto = 'Aluno: ' + informacoes.Nome + '\nEndereço: ' + informacoes.Endereco;

	carregarMapa(coordenadas[1], coordenadas[0], texto);

	registrarConsulta(informacoes.RA_Aluno, true)

	mensagemSucesso('Aluno encontrado!');
}

function registrarConsulta(numeroRA, alunoEncontrado) {
	$.ajax({
		url: serviceBaseUrl + 'localizarAluno/gravarAcesso?ra=' + numeroRA + '&alunoEncontrado=' + alunoEncontrado,
		contentType: 'application/json; charset=utf-8',
		type: 'POST'
	})
}

function mensagemInformação(textoMensagem) {
	toastr.info(textoMensagem);
}

function mensagemSucesso(textoMensagem) {
	toastr.success(textoMensagem);
}

function carregarMapa(latitude, longitude, title) {

	var coordenadas = new google.maps.LatLng(latitude, longitude);

	var marker = new google.maps.Marker({
		position: coordenadas,
		map: map,
		title: title,
		animation: google.maps.Animation.DROP
	});

	var map;

	function initialize() {
		var mapOptions = {
			zoom: 16,
			center: coordenadas
		};
		map = new google.maps.Map(document.getElementById('map-canvas'), mapOptions);

		marker.setMap(map);
	}

	initialize();
}