function handleDimensionsUpdate($inputX, $inputY, $inputZ, $inputResult) {
    var calculatedDimensions = 0;
    var inputX,
        inputY,
        inputZ;

    $inputX.on("change", function (event) {
        recalculateDimensions()
    });
    $inputY.on("change", function (event) {
        recalculateDimensions()
    });
    $inputZ.on("change", function (event) {
        recalculateDimensions()
    });

    function recalculateDimensions() {
        inputX = parseFloat($inputX.val().replace(",","."));
        inputY = parseFloat($inputY.val().replace(",","."));
        inputZ = parseFloat($inputZ.val().replace(",","."));

        calculatedDimensions = inputX * inputY * inputZ;
        $inputResult.val(calculatedDimensions);
    }
}