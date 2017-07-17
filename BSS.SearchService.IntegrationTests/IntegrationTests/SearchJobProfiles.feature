@IntegrationTests
Feature: SearchJobProfiles

Feature: Locate Job Profiles - Search By Keyword
	In order to locate job profiles I am interested in
	As a Citizen
	I want to be able to search for job profiles by keyword

Scenario: Locate Job Profiles - Search By Keyword - returns matching results when matched in <Title>
	Given a set of job profiles as follows
	| Title | AlternativeTitle                       | 
	| Doctor | GP | 
	| Hospital Doctor | Bloke in a hospital | 
	| Keg Sniffer | drunkered | 
	When I search for the keyword "Doctor"
	Then I should see "2" results
	And the results should contain the following
	| Title | AlternativeTitle                       | 
	| Doctor | GP | 
	| Hospital Doctor | Bloke in a hospital | 


Scenario: Locate Job Profiles - Search By Keyword - returns matching results when matched in <AltTitle>
	Given a set of job profiles as follows
	| Title | AlternativeTitle |
	| GP    | Doctor           |
	| Bloke in a hospital | Hospital Doctor  |
	| Keg Sniffer | drunkered | 
	When I search for the keyword "Doctor"
	Then I should see "2" results
	And the results should contain the following
	| Title | AlternativeTitle                       | 
	| GP    | Doctor           |
	| Bloke in a hospital | Hospital Doctor  |


	Scenario: Locate Job Profiles - Search By Keyword - returns matching results when matched in both <Title> and <AltTitle>
	Given a set of job profiles as follows
	| Title | AlternativeTitle |
	| GP Doctor    | Doctor           |
	| Doctor in a hospital | Hospital Doctor  |
	| Keg Sniffer | drunkered | 
	When I search for the keyword "Doctor"
	Then I should see "2" results
	And the results should contain the following
	| Title | AlternativeTitle                       | 
	| GP Doctor    | Doctor           |
	| Doctor in a hospital | Hospital Doctor  |

	Scenario: Locate Job Profiles - Search By Keyword - returns no matching results when keywords do not match either <Title> and <AltTitle>
	Given a set of job profiles as follows
	| Title | AlternativeTitle |
	| GP Doctor    | Doctor           |
	| Doctor in a hospital | Hospital Doctor  |
	| Keg Sniffer | drunkered | 
	When I search for the keyword "Plumber"
	Then I should see "2" results
	And the results should contain the following
	| Title | AlternativeTitle                       | 