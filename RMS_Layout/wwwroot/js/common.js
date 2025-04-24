


function clearFormControls(formSelector) {
	const $form = $(formSelector);

	$form.find('input[type=text], input[type=password], input[type=email], textarea, select')
		.val('');

	$form.find('input[type=checkbox], input[type=radio]')
		.prop('checked', false);

	// Reset select2 or any enhanced dropdowns if you're using them
	$form.find('select').trigger('change');

	// Clear validation messages (optional)
	$form.find('.field-validation-error, .text-danger').empty();

	// Optional: set focus back to the first visible and enabled input field
/*	$form.find('input:visible:enabled:first').focus();*/

	// Optionally: reset entire form (if you want built-in reset behavior)
	// $form[0].reset();
}


function grid_Limit()
{
	const limit = 10;
	return limit;
}