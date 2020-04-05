Feature: GumtreeFeature
	I search for Cars, Vans & Utes
	I click on a Page Number of the pager
	I click on a random advert on this page
	I click on Images button on advert
	I cycle through all available images by clicking the right slider

@BasePage
Scenario: Verify search engine from Gumtree
	When I search Categories '<Categories>' and Keywords '<Keywords>' and Location '<Locations>' and  Radius '<Radius>'
	And The number of results under Most Recent for page and the number of results show in label should  be '<Result>'
	And I click on a random advert on  this page
	And I click on Images button on   advert
	Then I cycle through all available images by clicking the  right slider

Scenarios: 
	| Categories 							| Keywords 		| Locations 				| Radius | Result |
	| Cars & Vehicles;Cars, Vans & Utes  	| Toyota        | Wollongong Region, NSW    | 250 KM | 24     |
	| Cars & Vehicles;Cars, Vans & Utes     | Toyota        | Wollongong Region, NSW    | 50 KM  | 24     |
		