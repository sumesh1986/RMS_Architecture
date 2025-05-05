


function clearFormControls(formSelector) {
    const $form = $(formSelector);

    // Clear text, password, email, and textarea fields
    $form.find('input[type=text], input[type=password], input[type=email], textarea')
        .val('');

    // Uncheck all checkboxes and radio buttons
    $form.find('input[type=checkbox], input[type=radio]')
        .prop('checked', false);

    // Reset dropdowns to default (option with value="0")
    $form.find('select:not([multiple])').each(function () {
        if ($(this).find('option[value="0"]').length > 0) {
            $(this).val('0');
        } else {
            $(this).val('');
        }
        $(this).trigger('change'); // For select2 or other plugins
    });

    // Clear ListBox (multi-selects)
    $form.find('select[multiple]').empty();

    // Clear validation messages
    $form.find('.field-validation-error, .text-danger').empty();

    // Optional: focus first visible input
    // $form.find('input:visible:enabled:first').focus();
}



function grid_Limit()
{
	const limit = 10;
	return limit;
}