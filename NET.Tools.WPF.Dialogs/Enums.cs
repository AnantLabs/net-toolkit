using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using NET.Tools.WPF.Skins;


namespace NET.Tools.WPF
{
    #region Enums

    /// <summary>
    /// \addtogroup enums
    /// @{
    /// </summary>
    public enum MessageButtons
    {
        OK,
        OKCancel,
        YesNo,
        YesNoCancel
    }

    public enum MessageIcons
    {
        None,
        Info,
        Error,
        Warn,
        Qestion,
        OK
    }

    public enum MessageResults
    {
        OK,
        Yes,
        No,
        Cancel
    }
    /// @}

    #endregion

    internal static class MessageIconHelper
    {
        public static ImageSource GetIcon(MessageIcons icon, SkinBundle bundle)
        {
            switch (icon)
            {
                case MessageIcons.None:
                    return null;
                case MessageIcons.Info:
                    if ((bundle != null) && (bundle.InfoIcon != null))
                        return bundle.InfoIcon;
                    else
                        return ResourceManager.IMAGE_INFO;
                case MessageIcons.Error:
                    if ((bundle != null) && (bundle.ErrorIcon != null))
                        return bundle.ErrorIcon;
                    else
                        return ResourceManager.IMAGE_ERROR;
                case MessageIcons.Warn:
                    if ((bundle != null) && (bundle.WarnIcon != null))
                        return bundle.WarnIcon;
                    else
                        return ResourceManager.IMAGE_WARN;
                case MessageIcons.Qestion:
                    if ((bundle != null) && (bundle.QuestionIcon != null))
                        return bundle.QuestionIcon;
                    else
                        return ResourceManager.IMAGE_QUESTION;
                case MessageIcons.OK:
                    if ((bundle != null) && (bundle.OKIcon != null))
                        return bundle.OKIcon;
                    else
                        return ResourceManager.IMAGE_OK;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
