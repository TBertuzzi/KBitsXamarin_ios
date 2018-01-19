using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace KBitsXamarin_ios
{
    public partial class ViewController : UIViewController
    {

        public List<string> NumerosTelefone { get; set; }

        protected ViewController(IntPtr handle) : base(handle)
        {
            NumerosTelefone = new List<string>();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            string numeroTraduzido = "";
                
            //Evento de Clique do Botao para Alterar as Letras em Numeros
            btnTraduzir.TouchUpInside += (object sender, EventArgs e) => {
                // Converte Letras em Numeros
                // utiliza a PhoneTranslator.cs
                numeroTraduzido = PhoneTranslator.ToNumber(
                    txtNumero.Text);

                // Retira o Teclado após a confirmação da digitação
                txtNumero.ResignFirstResponder();

                if (numeroTraduzido == "")
                {
                    btnLigar.SetTitle("Ligar ", UIControlState.Normal);
                    btnLigar.Enabled = false;
                }
                else
                {
                    btnLigar.SetTitle("Ligar " + numeroTraduzido,
                        UIControlState.Normal);
                    btnLigar.Enabled = true;
                }
            };

            btnLigar.TouchUpInside += (object sender, EventArgs e) => {

                //Armazena os Numeros Traduzidos
                NumerosTelefone.Add(numeroTraduzido);

                // Utiliza URL handler para chamar a função de ligar do IOS
                var url = new NSUrl("tel:" + numeroTraduzido);

                //Caso não consiga exibe o alerta
                if (!UIApplication.SharedApplication.OpenUrl(url))
                {
                    var alerta = UIAlertController.Create("Não suprotado", "'tel:' não é suportado pelo device atual", UIAlertControllerStyle.Alert);
                    alerta.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
                    PresentViewController(alerta, true, null);
                }
            };

            //Chama pelo evento
            //btnExibirHistorico.TouchUpInside += (object sender, EventArgs e) => {
            //    // Launches a new instance of CallHistoryController
            //    HistoricoController historico = this.Storyboard.InstantiateViewController("HistoricoController") as HistoricoController;
            //    if (historico != null)
            //    {
            //        historico.NumerosTelefone = NumerosTelefone;
            //        this.NavigationController.PushViewController(historico, true);
            //    }
            //};
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        //utilizando Navegação da History Board
        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            // seta para qual viewController vai


            var callHistoryContoller = segue.DestinationViewController as HistoricoController;

            //envia os parametros para ViewController

            if (callHistoryContoller != null)
            {
                callHistoryContoller.NumerosTelefone = NumerosTelefone;
            }
        }
    }
}
