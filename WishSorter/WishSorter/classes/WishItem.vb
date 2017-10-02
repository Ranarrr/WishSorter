Imports WishSorter.Functions

Public Class WishItem
	Private LinkToSite As String
	Private priceOfItem As Integer
	Private isItemFree As Boolean
	Private LinkToImage As String

	Public Sub New(ByVal link As String, price As Integer, isFree As Boolean, linkImage As String)
		LinkToSite = link
		priceOfItem = price
		isItemFree = isFree
		LinkToImage = linkImage
	End Sub

	Property getsetLinkSite() As String
		Get
			Return LinkToSite
		End Get
		Set(value As String)
			LinkToSite = value
		End Set
	End Property

	Property getsetPrice() As Integer
		Get
			Return priceOfItem
		End Get
		Set(value As Integer)
			priceOfItem = value
		End Set
	End Property

	Property getsetIsFree() As Boolean
		Get
			Return isItemFree
		End Get
		Set(value As Boolean)
			isItemFree = value
		End Set
	End Property

	Property getsetLinkImage() As String
		Get
			Return LinkToImage
		End Get
		Set(value As String)
			LinkToImage = value
		End Set
	End Property
End Class