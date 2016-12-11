function handleDimensionsUpdate($inputXI, $inputYI, $inputZI, $inputResultI, $inputXC, $inputYC, $inputZC, $inputResultC) {
    var calculatedDimensions = 0;
    var result = 0;
    var inputX,
        inputY,
        inputZ;

    $inputXI.on("change", function (event) {
        toCm($inputXI, $inputXC);
        recalculateDimensionsI();
        recalculateDimensionsC();
    });
    $inputYI.on("change", function (event) {
        toCm($inputYI, $inputYC);
        recalculateDimensionsI();
        recalculateDimensionsC();
    });
    $inputZI.on("change", function (event) {
        toCm($inputZI, $inputZC);
        recalculateDimensionsI();
        recalculateDimensionsC();
    });
    $inputXC.on("change", function (event) {
        toInches($inputXI, $inputXC);
        recalculateDimensionsC();
        recalculateDimensionsI();
    });
    $inputYC.on("change", function (event) {
        toInches($inputYI, $inputYC);
        recalculateDimensionsC();
        recalculateDimensionsI();
    });
    $inputZC.on("change", function (event) {
        toInches($inputZI, $inputZC);
        recalculateDimensionsC();
        recalculateDimensionsI();
    });

    function recalculateDimensionsI() {
        inputX = parseFloat($inputXI.val().replace(",", "."));
        inputY = parseFloat($inputYI.val().replace(",", "."));
        inputZ = parseFloat($inputZI.val().replace(",", "."));

        calculatedDimensions = inputX * inputY * inputZ;
        $inputResultI.val(calculatedDimensions);
    }
    function recalculateDimensionsC() {
        inputX = parseFloat($inputXC.val().replace(",", "."));
        inputY = parseFloat($inputYC.val().replace(",", "."));
        inputZ = parseFloat($inputZC.val().replace(",", "."));

        calculatedDimensions = inputX * inputY * inputZ;
        $inputResultC.val(calculatedDimensions);
    }
    function toInches($inputInches, $inputCm) {
        result = parseFloat($inputCm.val().replace(",", "."));
        $inputInches.val(result / 2.54);
    }
    function toCm($inputInches, $inputCm) {
        result = parseFloat($inputInches.val().replace(",", "."));
        $inputCm.val(result * 2.54);
    }
}

function handleDimensionsInput($inputInches, $inputCm) {
    var result = 0;

    $inputInches.on("change", function (event) {
        result = parseFloat($inputInches.val().replace(",", "."));
        $inputCm.val(result * 2.54);
    });
    $inputCm.on("change", function (event) {
        result = parseFloat($inputInches.val().replace(",", "."));
        $inputInches.val(result / 2.54);
    });
}

//function handleDimensionsUpdate($inputX, $inputY, $inputZ, $inputResult) {
//    var calculatedDimensions = 0;
//    var inputX,
//        inputY,
//        inputZ;

//    $inputX.on("change", function (event) {
//        recalculateDimensions()
//    });
//    $inputY.on("change", function (event) {
//        recalculateDimensions()
//    });
//    $inputZ.on("change", function (event) {
//        recalculateDimensions()
//    });

//    function recalculateDimensions() {
//        inputX = parseFloat($inputX.val().replace(",","."));
//        inputY = parseFloat($inputY.val().replace(",","."));
//        inputZ = parseFloat($inputZ.val().replace(",","."));

//        calculatedDimensions = inputX * inputY * inputZ;
//        $inputResult.val(calculatedDimensions);
//    }
//}