Imports System.ComponentModel.DataAnnotations

Public Class ClienteModel

    <Required> Public Property Accion As String
    <Required> Public Property Bpartner As String
    <Required> Public Property City As String
    <Required> Public Property Country As String
    <Required> Public Property District As String
    <Required> Public Property EmpresaPersonal As String
    Public Property EMail As String
    Public Property Giro As String
    Public Property GroupClient As String
    Public Property ConOrdenCompra As String
    <Required> Public Property Name1 As String
    Public Property Name2 As String
    Public Property Name3 As String
    Public Property Name4 As String
    <Required> Public Property Region As String
    <Required> Public Property Street As String
    <Required> Public Property StrSuppl1 As String
    <Required> Public Property TaxNumber As String
    Public Property Telephone As String
    Public Property TelMovil As String
    <Required> Public Property TitleKey As String
    Public Property CargoEmpleado As String
    <Required(AllowEmptyStrings:=True)> Public Property DescCargoEmpleado As String
    Public Property ListaPrecio As String
    Public Property Localidad As String
    Public Property ZonaTransporte As String
    Public Property Sociedad As String
    Public Property AgruInterComercial As String
    Public Property GrupoCuenta As String
    Public Property Idioma As String
    Public Property HusoHorario As String
    <Required> Public Property TipoIdentificacion As String
    Public Property ProcReclamacion As String
    Public Property Cuenta As String
    Public Property GrupoTesoreria As String
    Public Property IndIntereses As String
    Public Property ClasificacionFiscal As String
    Public Property DirAlternativa As Diralternativa()
    Public Property DatosComerciales As Datoscomerciales()
    Public Property PersonasContacto As Personascontacto()

    Public Sub New()
        'constructor predeterminado
    End Sub

    Public Sub New(accion As String, bpartner As String, city As String, country As String, district As String, empresaPersonal As String, eMail As String, giro As String, groupClient As String, conOrdenCompra As String, name1 As String,
                   name2 As String, name3 As String, name4 As String, region As String, street As String, strSuppl1 As String, taxNumber As String, telephone As String, telMovil As String, titleKey As String, cargoEmpleado As String,
                   descCargoEmpleado As String, listaPrecio As String, localidad As String, zonaTransporte As String, sociedad As String, agruInterComercial As String, grupoCuenta As String, idioma As String, husoHorario As String,
                   tipoIdentificacion As String, procReclamacion As String, cuenta As String, grupoTesoreria As String, indIntereses As String, clasificacionFiscal As String, dirAlternativa() As Diralternativa, datosComerciales() As Datoscomerciales,
                   personasContacto() As Personascontacto)
        Me.Accion = accion
        Me.Bpartner = bpartner
        Me.City = city
        Me.Country = country
        Me.District = district
        Me.EmpresaPersonal = empresaPersonal
        Me.EMail = eMail
        Me.Giro = giro
        Me.GroupClient = groupClient
        Me.ConOrdenCompra = conOrdenCompra
        Me.Name1 = name1
        Me.Name2 = name2
        Me.Name3 = name3
        Me.Name4 = name4
        Me.Region = region
        Me.Street = street
        Me.StrSuppl1 = strSuppl1
        Me.TaxNumber = taxNumber
        Me.Telephone = telephone
        Me.TelMovil = telMovil
        Me.TitleKey = titleKey
        Me.CargoEmpleado = cargoEmpleado
        Me.DescCargoEmpleado = descCargoEmpleado
        Me.ListaPrecio = listaPrecio
        Me.Localidad = localidad
        Me.ZonaTransporte = zonaTransporte
        Me.Sociedad = sociedad
        Me.AgruInterComercial = agruInterComercial
        Me.GrupoCuenta = grupoCuenta
        Me.Idioma = idioma
        Me.HusoHorario = husoHorario
        Me.TipoIdentificacion = tipoIdentificacion
        Me.ProcReclamacion = procReclamacion
        Me.Cuenta = cuenta
        Me.GrupoTesoreria = grupoTesoreria
        Me.IndIntereses = indIntereses
        Me.ClasificacionFiscal = clasificacionFiscal
        Me.DirAlternativa = dirAlternativa
        Me.DatosComerciales = datosComerciales
        Me.PersonasContacto = personasContacto
    End Sub
End Class

Public Class Diralternativa
    Public Property Partner As String
    Public Property City As String
    Public Property Localidad As String
    Public Property District As String
    Public Property Street As String
    Public Property StrSuppl1 As String
    Public Property Country As String
    Public Property Region As String
    Public Property Telephone As String
    Public Property TelMovil As String
    Public Property EMail As String

    Public Sub New(partner As String, city As String, localidad As String, district As String, street As String, strSuppl1 As String, country As String, region As String, telephone As String, telMovil As String, eMail As String)
        Me.Partner = partner
        Me.City = city
        Me.Localidad = localidad
        Me.District = district
        Me.Street = street
        Me.StrSuppl1 = strSuppl1
        Me.Country = country
        Me.Region = region
        Me.Telephone = telephone
        Me.TelMovil = telMovil
        Me.EMail = eMail
    End Sub
End Class

Public Class Datoscomerciales
    Public Property OrgVentas As String
    Public Property Canal As String
    Public Property Sector As String
    Public Property ZonaVentas As String
    Public Property OficVentas As String
    Public Property GrupoVendedores As String
    Public Property Moneda As String
    Public Property EsquemaCliente As String
    Public Property GrupoEstadCliente As String
    Public Property PrioEntrega As String
    Public Property CondExpedicion As String
    Public Property CondPago As String
    Public Property GrupoImpuCliente As String

    Public Sub New(orgVentas As String, canal As String, sector As String, zonaVentas As String, oficVentas As String, grupoVendedores As String, moneda As String, esquemaCliente As String, grupoEstadCliente As String, prioEntrega As String,
                   condExpedicion As String, condPago As String, grupoImpuCliente As String)
        Me.OrgVentas = orgVentas
        Me.Canal = canal
        Me.Sector = sector
        Me.ZonaVentas = zonaVentas
        Me.OficVentas = oficVentas
        Me.GrupoVendedores = grupoVendedores
        Me.Moneda = moneda
        Me.EsquemaCliente = esquemaCliente
        Me.GrupoEstadCliente = grupoEstadCliente
        Me.PrioEntrega = prioEntrega
        Me.CondExpedicion = condExpedicion
        Me.CondPago = condPago
        Me.GrupoImpuCliente = grupoImpuCliente
    End Sub
End Class

Public Class Personascontacto
    Public Property PCPARTNER As String
    Public Property CodFuncion As String
    Public Property Funcion As String
    Public Property NombrePC As String
    Public Property ApellidoPC As String
    Public Property CityPC As String
    Public Property DistrictPC As String
    Public Property StreetPC As String
    Public Property HouseNum1PC As String
    Public Property CountryPC As String
    Public Property TelephonePC As String
    Public Property TelMovilPC As String
    Public Property EMailPC As String

    Public Sub New(pCPARTNER As String, codFuncion As String, funcion As String, nombrePC As String, apellidoPC As String, cityPC As String, districtPC As String, streetPC As String, houseNum1PC As String, countryPC As String, telephonePC As String,
                   telMovilPC As String, eMailPC As String)
        Me.PCPARTNER = pCPARTNER
        Me.CodFuncion = codFuncion
        Me.Funcion = funcion
        Me.NombrePC = nombrePC
        Me.ApellidoPC = apellidoPC
        Me.CityPC = cityPC
        Me.DistrictPC = districtPC
        Me.StreetPC = streetPC
        Me.HouseNum1PC = houseNum1PC
        Me.CountryPC = countryPC
        Me.TelephonePC = telephonePC
        Me.TelMovilPC = telMovilPC
        Me.EMailPC = eMailPC
    End Sub
End Class
