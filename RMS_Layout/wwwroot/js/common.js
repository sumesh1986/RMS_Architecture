


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

    $form.find('select').each(function () {
        $(this).empty(); // This will clear all <option> elements inside every <select>
    });


    // Clear validation messages
    $form.find('.field-validation-error, .text-danger').empty();

    // Optional: focus first visible input
    // $form.find('input:visible:enabled:first').focus();

    // Update any status labels for toggles inside this form
    $form.find('.toggle-status').each(function () {
        const labelSelector = $(this).data('label-target');
        if (labelSelector) {
            const $label = $(labelSelector);
            const type = $(this).attr('type');

            if (type === 'checkbox') {
                $label.text($(this).is(':checked') ? 'Active' : 'Inactive');
            } else if (type === 'radio') {
                const value = $form.find('input[name="' + $(this).attr('name') + '"]:checked').val();
                $label.text(value || '');
            }
        }
    });
}



function grid_Limit()
{
	const limit = 10;
	return limit;
}