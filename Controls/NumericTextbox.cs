using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Controls
{
    [ToolboxItem(true)]
    [Description("Textbox supporting only numeric values.")]
   public  class NumericTextBox : TextBox
    {

        #region Attributes

        private bool _isValidating = false;
        private string _lastValidValue = string.Empty;

        #endregion

        #region Properties

        [Category("Numeric")]
        [DefaultValue(true)]
        [Description("Indicates whether textbox should allow decimal values.")]
        public bool AllowDecimals { get; set; }

        [Category("Numeric")]
        [DefaultValue(true)]
        [Description("Indicates whether textbox should allow negative values.")]
        public bool AllowNegative { get; set; }

        #endregion

        public NumericTextBox()
        {
            AllowDecimals = true;
            AllowNegative = true;
        }

        #region Validation

        /// <inheritdoc />
        protected override void OnTextChanged(EventArgs e)
        {
            if (!_isValidating)
            {
                if (string.IsNullOrEmpty(Text) || IsValid())
                {
                    _lastValidValue = Text;
                    base.OnTextChanged(e);
                }
                else
                {
                    _isValidating = true;
                    Text = _lastValidValue;
                    SelectionStart = Text.Length;
                    _isValidating = false;
                }
            }
        }

        /// <summary>
        /// Evaluates whether number is valid for current settings.
        /// </summary>
        /// <returns>True, if number is valid; otherwise false.</returns>
        private bool IsValid()
        {
            if (AllowDecimals && AllowNegative)
            {
                return decimal.TryParse(Text, out decimal result);
            }
            else if (AllowDecimals)
            {
                return decimal.TryParse(Text, out decimal result) && result >= 0;
            }
            else if (AllowNegative)
            {
                return int.TryParse(Text, out int resultInt);
            }
            else
            {
                return int.TryParse(Text, out int resultInt) && resultInt >= 0;
            }
        }

        #endregion

    }
}
