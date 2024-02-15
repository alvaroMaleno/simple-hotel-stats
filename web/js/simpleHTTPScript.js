
//Functions Region

function get(pUrl){
    var Httpreq = new XMLHttpRequest(); 
    Httpreq.open("GET",pUrl,false);
    Httpreq.send();
    return Httpreq.responseText;          
}

function getCountriesObjectsFromHotelAPI(countries){
    const HOTELAPI_URL = "https://localhost:5001/HotelAPI/";
    const HOTELAPI_COUNTRIES = ["es", "fr", "it"];
    for (let i = 0; i < HOTELAPI_COUNTRIES.length; i++) {
        countries.push(JSON.parse(get(HOTELAPI_URL + HOTELAPI_COUNTRIES[i])));
    }
}

//We know there are only three for now
function getCountryNameFromIsoCode(iso){
    if(iso === "ES"){
        return "Spain"
    }else if(iso === "FR"){
        return "France"
    }else{
        return "Italy"
    }
}

function getResultFromCountries(countries){
    let innerReturn = '';
    let position = 0;
    for (let i = 0; i < countries.length; i++) {
        innerReturn += '<section class="Country">';
        innerReturn += `<div class="section-title"><h2>${getCountryNameFromIsoCode(countries[i].isoCountryId)}</h2>`
        innerReturn += `<h4>Average: ${countries[i].average}</h4></div>`;
        innerReturn += '<div class="position-preview">';

        position = 1;
        for (let [positionKeys, oHotelListValues] of Object.entries(countries[i].oHotelList)) {
            innerReturn += `<div class="position"><h3>Position ${position++}</h3>`;
            for (let [hotelPositionKeys, oHotelValues] of Object.entries(oHotelListValues)) {
                innerReturn += '<div class="hotel">'
                innerReturn += `<h4>Hotel Name:</br> ${oHotelValues.name}</h4>`;
                innerReturn += '<p class="preview"><b>Id:</b></br>' + oHotelValues.id + '</br>'
                innerReturn += '</br><b>Score:</b> ' + oHotelValues.score + '</br>'
                innerReturn += '</p>';
                innerReturn += '</div>'
            }
            innerReturn += '</div>';
        }
        innerReturn += '</div>';
        innerReturn += '</section>';
    }
    return innerReturn;
}

// Script Region

let countries = [];
getCountriesObjectsFromHotelAPI(countries);
let innerReturn = getResultFromCountries(countries);
document.getElementById('main-articles-box').innerHTML = innerReturn;

