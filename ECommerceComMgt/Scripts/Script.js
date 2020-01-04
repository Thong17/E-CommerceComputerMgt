
// multiple handled with value 
var pmdSliderValueRange = document.getElementById('pmd-slider-value-range');

noUiSlider.create(pmdSliderValueRange, {
    start: [100, 2000], // Handle start position
    connect: true, // Display a colored bar between the handles
    tooltips: [wNumb({ decimals: 0 }), wNumb({ decimals: 0 })],
    format: wNumb({
        decimals: 0,
        thousand: '',
        postfix: '',

    }),
    range: { // Slider can select '0' to '100'
        'min': 0,
        'max': 3000
    },
});

var valueMax = document.getElementById('value-max'),
    valueMin = document.getElementById('value-min');

// When the slider value changes, update the input and span
pmdSliderValueRange.noUiSlider.on('update', function (values, handle) {
    if (handle) {
        valueMax.innerText = '$' + values[handle];
    } else {
        valueMin.innerText = '$' + values[handle];
    }
});	
