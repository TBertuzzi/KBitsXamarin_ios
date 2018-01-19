// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace KBitsXamarin_ios
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnExibirHistorico { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnLigar { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnTraduzir { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtNumero { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnExibirHistorico != null) {
                btnExibirHistorico.Dispose ();
                btnExibirHistorico = null;
            }

            if (btnLigar != null) {
                btnLigar.Dispose ();
                btnLigar = null;
            }

            if (btnTraduzir != null) {
                btnTraduzir.Dispose ();
                btnTraduzir = null;
            }

            if (txtNumero != null) {
                txtNumero.Dispose ();
                txtNumero = null;
            }
        }
    }
}