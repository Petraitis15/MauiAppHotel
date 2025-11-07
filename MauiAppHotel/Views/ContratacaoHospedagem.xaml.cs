using MauiAppHotel.Models;

namespace MauiAppHotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{
    App PropriedadesApp;
    
    public ContratacaoHospedagem()
	{
		InitializeComponent();

        PropriedadesApp = (App)Application.Current;

        pck_quarto.ItemsSource = PropriedadesApp.lista_quartos;

        dtpck_checkin.MinimumDate = DateTime.Now;
        dtpck_checkin.MaximumDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, DateTime.Now.Day);
        dtpck_checkout.MinimumDate = dtpck_checkin.Date.AddDays(1);
        dtpck_checkout.MaximumDate = dtpck_checkin.Date.AddMonths(6);
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new Views.Sobre());
    }

    private async void Avancar(object sender, EventArgs e)
    {
        try
        {
            if (pck_quarto.SelectedItem == null)
            {
                await DisplayAlert("Aviso", "Selecione uma acomodação antes de prosseguir.", "OK");
                return;
            }

            if (stp_adultos.Value == 0)
            {
                DisplayAlert("Erro", "Necessário mínimo de 1 adulto.", "OK");
                return;
            }

            var quartoSelecionado = (Quarto)pck_quarto.SelectedItem;

            var info = new InfoHospedagem
            {
                Adultos = (int)stp_adultos.Value,
                Criancas = (int)stp_criancas.Value,
                Checkin = dtpck_checkin.Date,
                Checkout = dtpck_checkout.Date,
                Descricao = quartoSelecionado.Descricao,
                ValorDiariaAdulto = quartoSelecionado.ValorDiariaAdulto,
                ValorDiariaCrianca = quartoSelecionado.ValorDiariaCrianca
            };

            await Navigation.PushAsync(new HospedagemContratada(info));
        } catch (Exception ex)
        {
            DisplayAlert("Ops", ex.Message, "OK");
        }
    }

    private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
    {
        DatePicker elemento = sender as DatePicker;

        DateTime data_selecionada_checkin = elemento.Date;

        dtpck_checkout.MinimumDate = data_selecionada_checkin.AddDays(1);
        dtpck_checkout.MaximumDate = data_selecionada_checkin.AddMonths(6);
    }
}