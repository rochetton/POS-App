Namespace APIDESIS

    <System.SerializableAttribute(),
     System.ComponentModel.DesignerCategoryAttribute("code"),
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.w3.org/2003/05/soap-envelope"),
     System.Xml.Serialization.XmlRootAttribute(ElementName:="Envelope", [Namespace]:="http://www.w3.org/2003/05/soap-envelope", IsNullable:=False)>
    Partial Public Class EnvelopeConsultarEstado

        Private headerField As Object

        Private bodyField As EnvelopeBodyConsultarEstado

        Public Sub New()
            Me.Body = New APIDESIS.EnvelopeBodyConsultarEstado()
            Me.Body.ConsultarEstado = New APIDESIS.ConsultarEstado
            Me.Body.ConsultarEstado.login = New APIDESIS.ConsultarEstadoLogin()
        End Sub

        '''<remarks/>
        Public Property Header() As Object
            Get
                Return Me.headerField
            End Get
            Set
                Me.headerField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property Body() As EnvelopeBodyConsultarEstado
            Get
                Return Me.bodyField
            End Get
            Set
                Me.bodyField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.SerializableAttribute(),
    System.ComponentModel.DesignerCategoryAttribute("code"),
    System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.w3.org/2003/05/soap-envelope"),
    System.Xml.Serialization.XmlRootAttribute(ElementName:="EnvelopeBody", [Namespace]:="http://www.w3.org/2003/05/soap-envelope", IsNullable:=False)>
    Partial Public Class EnvelopeBodyConsultarEstado

        Private ConsultarEstadoField As ConsultarEstado

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://tempuri.org")>
        Public Property ConsultarEstado() As ConsultarEstado
            Get
                Return Me.ConsultarEstadoField
            End Get
            Set
                Me.ConsultarEstadoField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.SerializableAttribute(),
    System.ComponentModel.DesignerCategoryAttribute("code"),
    System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://tempuri.org"),
    System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://tempuri.org", IsNullable:=False)>
    Partial Public Class ConsultarEstado

        Private loginField As ConsultarEstadoLogin

        Private TrackIDField As String


        '''<remarks/>
        Public Property login() As ConsultarEstadoLogin
            Get
                Return Me.loginField
            End Get
            Set
                Me.loginField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property trackid() As String
            Get
                Return Me.TrackIDField
            End Get
            Set
                Me.TrackIDField = Value
            End Set
        End Property

    End Class

    '''<remarks/>
    <System.SerializableAttribute(),
    System.ComponentModel.DesignerCategoryAttribute("code"),
    System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://tempuri.org")>
    Partial Public Class ConsultarEstadoLogin

        Private usuarioField As String

        Private rutField As String

        Private claveField As String

        Private puertoField As String

        Private incluyeLinkField As Byte

        '''<remarks/>
        Public Property Usuario() As String
            Get
                Return Me.usuarioField
            End Get
            Set
                Me.usuarioField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property Rut() As String
            Get
                Return Me.rutField
            End Get
            Set
                Me.rutField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property Clave() As String
            Get
                Return Me.claveField
            End Get
            Set
                Me.claveField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property Puerto() As String
            Get
                Return Me.puertoField
            End Get
            Set
                Me.puertoField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property IncluyeLink() As Byte
            Get
                Return Me.incluyeLinkField
            End Get
            Set
                Me.incluyeLinkField = Value
            End Set
        End Property
    End Class

End Namespace
