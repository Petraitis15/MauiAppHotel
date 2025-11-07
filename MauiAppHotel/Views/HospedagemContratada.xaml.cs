using MauiAppHotel.Models;

namespace MauiAppHotel.Views;

public partial class HospedagemContratada : ContentPage
{
  
    public HospedagemContratada()
    {
        InitializeComponent();
    }

    
    public HospedagemContratada(InfoHospedagem info)
    {
        InitializeComponent();

        try
        {
            if (info == null)
            {
                DisplayAlert("Erro", "Informações da hospedagem não recebidas.", "OK");
                return;
            }

            lblDescricao.Text = info.Descricao;
            lblAdultos.Text = info.Adultos.ToString();
            lblCriancas.Text = info.Criancas.ToString();
            lblCheckin.Text = info.Checkin.ToString("dd/MM/yyyy");
            lblCheckout.Text = info.Checkout.ToString("dd/MM/yyyy");

            var dias = (info.Checkout - info.Checkin).Days;
            lblEstadia.Text = dias.ToString();

            double total = (info.Adultos * info.ValorDiariaAdulto + info.Criancas * info.ValorDiariaCrianca) * dias;

            lblValorTotal.Text = total.ToString("C");

        }
        catch (Exception ex)
        {
            DisplayAlert("Ops", ex.Message, "OK");
        }
    }

   
    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            await Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}
