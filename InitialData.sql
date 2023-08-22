USE [TravelPicker]
BEGIN TRANSACTION 
INSERT [dbo].[UserGroups] ([Id], [Name]) VALUES (N'd3879c65-a5e2-48fa-9e65-7da129062974', N'User')

INSERT [dbo].[UserGroups] ([Id], [Name]) VALUES (N'9f325469-1363-4fce-9715-9724ce9ef4af', N'Admin')

INSERT [dbo].[Users] ([Id], [Username], [Email], [Password], [Active], [LastLogin]) VALUES (N'14cce367-07cc-4a5c-bd1e-8c9f7d250b1c', N'Janez', N'kjanez1337@gmail.com', 0x532EAABD9574880DBF76B9B8CC00832C20A6EC113D682299550D7A6E0F345E25, 1, NULL)

INSERT [dbo].[UserUserGroup] ([UserGroupsId], [UsersId]) VALUES (N'd3879c65-a5e2-48fa-9e65-7da129062974', N'14cce367-07cc-4a5c-bd1e-8c9f7d250b1c')

INSERT [dbo].[UserUserGroup] ([UserGroupsId], [UsersId]) VALUES (N'9f325469-1363-4fce-9715-9724ce9ef4af', N'14cce367-07cc-4a5c-bd1e-8c9f7d250b1c')

INSERT [dbo].[GeoDbApiCallLog] ([Id], [RequestedById], [TimeStamp], [ServiceName], [ServiceMethodName], [StatusCode], [AdditionalData]) VALUES (N'2e938b75-29ed-46a7-b2b1-5b26ad3cd3c5', N'14cce367-07cc-4a5c-bd1e-8c9f7d250b1c', CAST(N'2023-06-29T18:07:56.3379891+00:00' AS DateTimeOffset), N'GeoSearchService', N'GetRandomCityInCountry', 200, NULL)

INSERT [dbo].[GeoDbApiCallLog] ([Id], [RequestedById], [TimeStamp], [ServiceName], [ServiceMethodName], [StatusCode], [AdditionalData]) VALUES (N'4fa5c82d-5302-46aa-8710-5b9e9df8b7d9', N'14cce367-07cc-4a5c-bd1e-8c9f7d250b1c', CAST(N'2023-06-29T16:02:08.5861265+00:00' AS DateTimeOffset), N'GeoSearchService', N'GetRandomCityInCountry', 200, NULL)

INSERT [dbo].[GeoDbApiCallLog] ([Id], [RequestedById], [TimeStamp], [ServiceName], [ServiceMethodName], [StatusCode], [AdditionalData]) VALUES (N'9a70c97a-f649-4d74-9405-61d2bf5ebe0b', N'14cce367-07cc-4a5c-bd1e-8c9f7d250b1c', CAST(N'2023-06-28T20:12:25.8995482+00:00' AS DateTimeOffset), N'GeoSearchService', N'GetRandomCityInCountry', 200, NULL)

INSERT [dbo].[GeoDbApiCallLog] ([Id], [RequestedById], [TimeStamp], [ServiceName], [ServiceMethodName], [StatusCode], [AdditionalData]) VALUES (N'd5ed3f4a-eb56-4c2f-beb5-d89814b86757', N'14cce367-07cc-4a5c-bd1e-8c9f7d250b1c', CAST(N'2023-06-29T15:56:32.8125377+00:00' AS DateTimeOffset), N'GeoSearchService', N'GetRandomCityInCountry', 200, NULL)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'0ec63092-4d3c-4800-921f-0548f05abe9b', N'CI', N'COTE D''IVOIRE', N'Cote D''Ivoire', N'CIV', 384, 225)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'879e4c59-49ca-4560-9759-0732316d88b9', N'HT', N'HAITI', N'Haiti', N'HTI', 332, 509)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'15fb140f-03a5-4bc2-a382-09b82d482bf9', N'CC', N'COCOS (KEELING) ISLANDS', N'Cocos (Keeling) Islands', NULL, NULL, 672)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'9406aaa6-0c68-4295-902d-0aa3f9ae93dd', N'MX', N'MEXICO', N'Mexico', N'MEX', 484, 52)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'4dfa6160-18d6-499c-b244-0b4ecda61bfd', N'AO', N'ANLA', N'Anla', N'A', 24, 244)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'c24bc36a-087e-4ce4-a630-0c553421a2c4', N'BY', N'BELARUS', N'Belarus', N'BLR', 112, 375)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'3706406b-a6e1-4097-94f7-0d7884b6c933', N'IS', N'ICELAND', N'Iceland', N'ISL', 352, 354)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'776c3d9a-d004-41fb-9e4c-0d8d30eb3260', N'KE', N'KENYA', N'Kenya', N'KEN', 404, 254)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'46841708-a32e-433b-8f89-0e5ea2c652b6', N'AU', N'AUSTRALIA', N'Australia', N'AUS', 36, 61)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'7c61a71b-5c2b-4299-8bb2-0eb8aced6d97', N'AS', N'AMERICAN SAMOA', N'American Samoa', N'ASM', 16, 1684)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'f6532374-44fe-4fba-a554-1033f3adff85', N'PN', N'PITCAIRN', N'Pitcairn', N'PCN', 612, 0)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'f9a57aa9-03f4-404e-8bd3-1088fb4d1b07', N'AR', N'ARGENTINA', N'Argentina', N'ARG', 32, 54)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'27e6892a-442f-4e1d-b0ba-11bea2cdb630', N'ZW', N'ZIMBABWE', N'Zimbabwe', N'ZWE', 716, 263)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'ea50ff91-8e18-4dce-83c6-13df7321bebe', N'RU', N'RUSSIAN FEDERATION', N'Russian Federation', N'RUS', 643, 70)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'5066ac91-002d-4063-8992-1528fa431e1e', N'VC', N'SAINT VINCENT AND THE GRENADINES', N'Saint Vincent and the Grenadines', N'VCT', 670, 1784)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'c85bc96a-7bb7-435d-b622-1558529be0b8', N'MW', N'MALAWI', N'Malawi', N'MWI', 454, 265)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'0cf95872-71e5-4cc0-81c8-16aa54fa5257', N'FR', N'FRANCE', N'France', N'FRA', 250, 33)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'2f5341ae-f7fe-44db-bd35-177555bd2174', N'BA', N'BOSNIA AND HERZEVINA', N'Bosnia and Herzevina', N'BIH', 70, 387)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'7bf9ec3c-b4ae-44c5-a9b7-17b7248b0636', N'SJ', N'SVALBARD AND JAN MAYEN', N'Svalbard and Jan Mayen', N'SJM', 744, 47)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'b04be830-3ec0-47b5-8285-19ea3b1692a0', N'AG', N'ANTIGUA AND BARBUDA', N'Antigua and Barbuda', N'ATG', 28, 1268)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'14c5b5c6-b424-42f9-942c-1bb41d64e838', N'ZA', N'SOUTH AFRICA', N'South Africa', N'ZAF', 710, 27)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'c9b5c15b-8b6b-4193-b8e2-1bd9fabecc60', N'MH', N'MARSHALL ISLANDS', N'Marshall Islands', N'MHL', 584, 692)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'edc0bd52-67fb-4954-97db-1c10cf4cb18c', N'TR', N'TURKEY', N'Turkey', N'TUR', 792, 90)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'd323108f-dd4c-4fe2-8672-1f806325de2e', N'SK', N'SLOVAKIA', N'Slovakia', N'SVK', 703, 421)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'431185d8-df6f-4c55-a4a0-2067090edc42', N'KH', N'CAMBODIA', N'Cambodia', N'KHM', 116, 855)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'604c6314-b18e-40d9-9346-2145f389435d', N'TJ', N'TAJIKISTAN', N'Tajikistan', N'TJK', 762, 992)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'59e67567-6171-47aa-93bc-21f82a811719', N'CD', N'CON, THE DEMOCRATIC REPUBLIC OF THE', N'Con, the Democratic Republic of the', N'COD', 180, 242)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'2aeacab4-b375-4c84-aef4-22e46027388e', N'TV', N'TUVALU', N'Tuvalu', N'TUV', 798, 688)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'b094efec-2bc8-45f6-9094-24f02304e58d', N'HR', N'CROATIA', N'Croatia', N'HRV', 191, 385)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'fe371d3f-de31-4bb7-afc2-263a665e26dd', N'SD', N'SUDAN', N'Sudan', N'SDN', 736, 249)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'5b8801a2-c6c5-4037-aa6e-26a624d7dbc7', N'MZ', N'MOZAMBIQUE', N'Mozambique', N'MOZ', 508, 258)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'ef0a6208-21b9-4951-807b-26e649d6fd35', N'CL', N'CHILE', N'Chile', N'CHL', 152, 56)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'e75ff64a-bce8-4e70-b719-27912845486f', N'PK', N'PAKISTAN', N'Pakistan', N'PAK', 586, 92)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'ce23a37c-7653-4924-bae4-28207752982d', N'WS', N'SAMOA', N'Samoa', N'WSM', 882, 684)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'8f4ffb7c-f9ce-468c-a702-2981346a1c49', N'BS', N'BAHAMAS', N'Bahamas', N'BHS', 44, 1242)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'8ea95849-c63d-42bc-a916-2c06f89a128b', N'SY', N'SYRIAN ARAB REPUBLIC', N'Syrian Arab Republic', N'SYR', 760, 963)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'fb40caf6-f37f-4676-92f7-2d53fe280cec', N'CR', N'COSTA RICA', N'Costa Rica', N'CRI', 188, 506)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'0600e6b1-290e-47eb-89c7-2de9ffa6f093', N'NF', N'NORFOLK ISLAND', N'Norfolk Island', N'NFK', 574, 672)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'763bbf27-939c-4233-9564-2efd00727a06', N'YT', N'MAYOTTE', N'Mayotte', NULL, NULL, 269)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'078e0392-dee3-4988-b583-2f2ed2dd92c5', N'NP', N'NEPAL', N'Nepal', N'NPL', 524, 977)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'698efb11-6a67-4ced-adbe-30aed1a5f45c', N'NL', N'NETHERLANDS', N'Netherlands', N'NLD', 528, 31)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'b9827ac0-e2f6-4a5f-bd6f-31498c1dc987', N'CG', N'CON', N'Con', N'COG', 178, 242)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'2c17eb8d-7a40-4e5d-bc2f-3347ce19d8e5', N'HN', N'HONDURAS', N'Honduras', N'HND', 340, 504)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'cdad66f7-17db-4e36-aecd-381ba8464b93', N'GP', N'GUADELOUPE', N'Guadeloupe', N'GLP', 312, 590)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'0fe7c97b-62af-47d3-817a-393ce9bee709', N'NE', N'NIGER', N'Niger', N'NER', 562, 227)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'a4aa060c-ba0d-4de8-861d-397d88f52d33', N'AN', N'NETHERLANDS ANTILLES', N'Netherlands Antilles', N'ANT', 530, 599)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'45202025-51e8-4c70-b506-3a6f96db172a', N'SI', N'SLOVENIA', N'Slovenia', N'SVN', 705, 386)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'4b512649-cd35-4d01-b6b1-3a99b55deb41', N'CZ', N'CZECH REPUBLIC', N'Czech Republic', N'CZE', 203, 420)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'4f703311-aaeb-4f1a-9bf7-3cc9c799f59f', N'GS', N'SOUTH GEORGIA AND THE SOUTH SANDWICH ISLANDS', N'South Georgia and the South Sandwich Islands', NULL, NULL, 0)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'67532326-b95c-4c38-900d-3e43872c6f77', N'GL', N'GREENLAND', N'Greenland', N'GRL', 304, 299)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'03a5d151-9d88-4697-a7cb-3f23024e4a3f', N'BO', N'BOLIVIA', N'Bolivia', N'BOL', 68, 591)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'6c18df85-b477-462a-8213-40342b5fe8c1', N'US', N'UNITED STATES', N'United States', N'USA', 840, 1)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'76f471b5-410c-4e9f-865d-408b46a18491', N'MQ', N'MARTINIQUE', N'Martinique', N'MTQ', 474, 596)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'a7b95811-9d17-420e-b0f3-41fd9ee4e03c', N'LU', N'LUXEMBOURG', N'Luxembourg', N'LUX', 442, 352)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'9d9dca31-72a8-4104-ad7c-42b859736149', N'ET', N'ETHIOPIA', N'Ethiopia', N'ETH', 231, 251)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'bd1c89be-0013-4958-b83a-431b484d7a02', N'GD', N'GRENADA', N'Grenada', N'GRD', 308, 1473)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'9289a032-2759-460b-aae4-433509eef363', N'MR', N'MAURITANIA', N'Mauritania', N'MRT', 478, 222)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'edf53e61-ee2e-47e9-a380-435b3039aafd', N'FK', N'FALKLAND ISLANDS (MALVINAS)', N'Falkland Islands (Malvinas)', N'FLK', 238, 500)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'f0abd44b-3524-41c6-bf24-43fa7e6eb981', N'KR', N'KOREA, REPUBLIC OF', N'Korea, Republic of', N'KOR', 410, 82)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'b491f38d-0784-4742-a39d-450dbf82c587', N'CV', N'CAPE VERDE', N'Cape Verde', N'CPV', 132, 238)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'77e8f4e8-7106-4065-8ed3-48048059e1d2', N'LR', N'LIBERIA', N'Liberia', N'LBR', 430, 231)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'a9071607-f2d0-4abe-a683-48366fedcaf8', N'SL', N'SIERRA LEONE', N'Sierra Leone', N'SLE', 694, 232)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'903e5158-b8e6-4a0d-b8ab-4c894b68ba87', N'VI', N'VIRGIN ISLANDS, U.S.', N'Virgin Islands, U.s.', N'VIR', 850, 1340)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'c2353b71-3a99-45cd-991a-4d4ab60419a0', N'GB', N'UNITED KINGDOM', N'United Kingdom', N'GBR', 826, 44)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'5161d0a7-5eb2-4220-ae93-4dc2f27a3029', N'KW', N'KUWAIT', N'Kuwait', N'KWT', 414, 965)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'0be489d3-af64-4898-9468-4ec0fd1dcd7a', N'DE', N'GERMANY', N'Germany', N'DEU', 276, 49)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'c5146022-e4c6-4bc1-961b-50577f02cd75', N'DO', N'DOMINICAN REPUBLIC', N'Dominican Republic', N'DOM', 214, 1809)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'9562a4fd-db9d-461f-a824-51b3485aeb7b', N'HM', N'HEARD ISLAND AND MCDONALD ISLANDS', N'Heard Island and Mcdonald Islands', NULL, NULL, 0)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'1274ae2a-21e1-4e40-b41b-5442d51f5bd5', N'DZ', N'ALGERIA', N'Algeria', N'DZA', 12, 213)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'49e0b90d-a12a-45a8-8b16-56bad354ac0b', N'SN', N'SENEGAL', N'Senegal', N'SEN', 686, 221)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'0b1d66f5-97a3-4612-a7bb-58dc5da71e9f', N'DM', N'DOMINICA', N'Dominica', N'DMA', 212, 1767)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'a722b0bf-6114-4849-b816-5c07a2fab125', N'TF', N'FRENCH SOUTHERN TERRITORIES', N'French Southern Territories', NULL, NULL, 0)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'8e2028b2-04b8-4eca-91ce-5c6bd7957bea', N'FO', N'FAROE ISLANDS', N'Faroe Islands', N'FRO', 234, 298)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'e839dc3f-d491-49df-bc3d-5ca086bb1a25', N'ID', N'INDONESIA', N'Indonesia', N'IDN', 360, 62)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'a3a26db3-af22-4ed3-945f-5d071355823c', N'BN', N'BRUNEI DARUSSALAM', N'Brunei Darussalam', N'BRN', 96, 673)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'244f44d2-6ec5-4d53-9d08-5d1f0ef045d2', N'FI', N'FINLAND', N'Finland', N'FIN', 246, 358)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'a282bbc5-944e-43d0-b9ba-6015ab8cdc12', N'SB', N'SOLOMON ISLANDS', N'Solomon Islands', N'SLB', 90, 677)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'347db2d8-89fc-43d7-a356-601747a4d6c6', N'ER', N'ERITREA', N'Eritrea', N'ERI', 232, 291)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'f754966f-91ff-49e5-aa14-620379899cea', N'RW', N'RWANDA', N'Rwanda', N'RWA', 646, 250)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'44d22b94-dc5d-4768-86a8-63a8452eeaf3', N'MD', N'MOLDOVA, REPUBLIC OF', N'Moldova, Republic of', N'MDA', 498, 373)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'ebb3853a-e7b8-46de-bab2-652d32af3d20', N'MM', N'MYANMAR', N'Myanmar', N'MMR', 104, 95)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'bb6e65de-14c8-487e-8b37-65ba6258b82a', N'PS', N'PALESTINIAN TERRITORY, OCCUPIED', N'Palestinian Territory, Occupied', NULL, NULL, 970)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'c351bb80-3184-4c28-8f51-6634448e2efe', N'EG', N'EGYPT', N'Egypt', N'EGY', 818, 20)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'f4da2f94-a4f6-4f59-b825-66dfb6fb0f14', N'AD', N'ANDORRA', N'Andorra', N'AND', 20, 376)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'4e912a19-b3a4-4697-8fc2-68a2fd6164c3', N'NO', N'NORWAY', N'Norway', N'NOR', 578, 47)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'99efc639-1cc5-4e93-9513-690f8e633370', N'KP', N'KOREA, DEMOCRATIC PEOPLE''S REPUBLIC OF', N'Korea, Democratic People''s Republic of', N'PRK', 408, 850)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'bc8c2b93-3d30-4069-aace-697b5e1bb289', N'TT', N'TRINIDAD AND TOBA', N'Trinidad and Toba', N'TTO', 780, 1868)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'a3c54f0d-591e-46fd-9be1-69cb25cd55f6', N'GN', N'GUINEA', N'Guinea', N'GIN', 324, 224)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'b6f7c574-3f1f-4c19-83f9-6aeab18c7b6a', N'YE', N'YEMEN', N'Yemen', N'YEM', 887, 967)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'0c8e2cc6-cc0e-4f6f-bfff-6c9b6a0f95cb', N'LY', N'LIBYAN ARAB JAMAHIRIYA', N'Libyan Arab Jamahiriya', N'LBY', 434, 218)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'335e7d0a-debc-4c87-88fe-6de3b66d00dd', N'CX', N'CHRISTMAS ISLAND', N'Christmas Island', NULL, NULL, 61)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'd8ee2b0a-2333-4b4a-b949-6e934282988a', N'AI', N'ANGUILLA', N'Anguilla', N'AIA', 660, 1264)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'c4ddde42-505c-4642-8df1-6f3c90fcafab', N'IL', N'ISRAEL', N'Israel', N'ISR', 376, 972)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'5a1d9f21-119e-4b29-9b77-6f5906d29fea', N'GY', N'GUYANA', N'Guyana', N'GUY', 328, 592)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'd7754c9e-e89a-4c0e-aed6-6f69e016ef85', N'JP', N'JAPAN', N'Japan', N'JPN', 392, 81)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'1c8f190d-9e4e-44a9-9c7a-6f81d7d7eeba', N'GH', N'GHANA', N'Ghana', N'GHA', 288, 233)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'a7da8d28-73b9-4675-9bdb-7047888978e6', N'CM', N'CAMEROON', N'Cameroon', N'CMR', 120, 237)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'c8832b6e-50f3-4c87-b1c1-714ba945d48d', N'GW', N'GUINEA-BISSAU', N'Guinea-Bissau', N'GNB', 624, 245)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'5dd82906-0207-4b9d-a3e3-71bbabf67030', N'BV', N'BOUVET ISLAND', N'Bouvet Island', NULL, NULL, 0)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'bd46eb4c-a3ee-4c27-8264-7284459234c0', N'MT', N'MALTA', N'Malta', N'MLT', 470, 356)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'4ff8bfd6-2ff8-4068-b763-72d87f02aaa2', N'NC', N'NEW CALEDONIA', N'New Caledonia', N'NCL', 540, 687)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'fdfbaea2-6e36-4ed6-af87-7317c663d0b6', N'BG', N'BULGARIA', N'Bulgaria', N'BGR', 100, 359)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'7559cc81-d890-4190-8d56-735f512ea49d', N'TZ', N'TANZANIA, UNITED REPUBLIC OF', N'Tanzania, United Republic of', N'TZA', 834, 255)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'0ad9631d-bf17-4dae-8cdc-767c54c1f62d', N'SE', N'SWEDEN', N'Sweden', N'SWE', 752, 46)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'd4e93ae0-6598-4ccd-b4f5-771a374dffb4', N'UG', N'UGANDA', N'Uganda', N'UGA', 800, 256)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'62ca529f-02a2-448d-8679-77e6a1caee10', N'MC', N'MONACO', N'Monaco', N'MCO', 492, 377)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'b2c7febf-1653-4361-af90-79e1d4c1e83a', N'SO', N'SOMALIA', N'Somalia', N'SOM', 706, 252)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'd1f5cad6-279d-426d-b680-7a8f68f93506', N'CA', N'CANADA', N'Canada', N'CAN', 124, 1)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'9c958e97-303c-427d-8a97-7b67c6d370f3', N'PW', N'PALAU', N'Palau', N'PLW', 585, 680)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'4f58425f-fe4e-4216-ba76-7b9fe664f16b', N'LA', N'LAO PEOPLE''S DEMOCRATIC REPUBLIC', N'Lao People''s Democratic Republic', N'LAO', 418, 856)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'45e42b69-f851-4baf-937a-7c86340f5e62', N'TW', N'TAIWAN, PROVINCE OF CHINA', N'Taiwan, Province of China', N'TWN', 158, 886)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'00eecc34-9d1b-42d6-a34a-7ffb0e143435', N'SG', N'SINGAPORE', N'Singapore', N'SGP', 702, 65)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'035b6329-164e-4974-a4f2-8266fd0fa77a', N'SA', N'SAUDI ARABIA', N'Saudi Arabia', N'SAU', 682, 966)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'ac896bce-17f2-4803-9cc1-83aff3399c6b', N'PG', N'PAPUA NEW GUINEA', N'Papua New Guinea', N'PNG', 598, 675)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'7f08a6e5-1cd3-4182-88f9-84aa6a5e5794', N'LV', N'LATVIA', N'Latvia', N'LVA', 428, 371)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'8a963242-91f0-4709-b687-85ce42821221', N'KI', N'KIRIBATI', N'Kiribati', N'KIR', 296, 686)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'0b12dcc7-1131-458c-85f8-87465377fee5', N'LS', N'LESOTHO', N'Lesotho', N'LSO', 426, 266)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'f3f0ba37-907b-4980-8cd8-8786fc48f1a4', N'LB', N'LEBANON', N'Lebanon', N'LBN', 422, 961)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'f24becab-411b-46d1-b512-8827b5170586', N'BW', N'BOTSWANA', N'Botswana', N'BWA', 72, 267)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'58d406c2-2f72-45d2-adb1-883f99347fb2', N'PE', N'PERU', N'Peru', N'PER', 604, 51)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'8e567699-fdda-4c15-9e8b-884f06e96b73', N'UA', N'UKRAINE', N'Ukraine', N'UKR', 804, 380)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'6d5f1a9a-d15a-4bde-9718-892acac2f031', N'BH', N'BAHRAIN', N'Bahrain', N'BHR', 48, 973)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'4eefb3d2-0c3f-4ec3-831e-89e655cb4128', N'PH', N'PHILIPPINES', N'Philippines', N'PHL', 608, 63)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'21b579ab-0572-45bf-a8a7-89f1bc5de34f', N'NG', N'NIGERIA', N'Nigeria', N'NGA', 566, 234)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'4c2d57a1-99c5-49e6-9044-8a2a4d316a56', N'TG', N'TO', N'To', N'T', 768, 228)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'5729be5f-d28d-419e-9da3-8fefc1f0f7d9', N'TD', N'CHAD', N'Chad', N'TCD', 148, 235)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'fd4a0c91-32a3-4f3e-9c14-91316d8c2b84', N'SV', N'EL SALVADOR', N'El Salvador', N'SLV', 222, 503)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'2ddcd5f1-2392-4020-b9bb-9163c065937f', N'VA', N'HOLY SEE (VATICAN CITY STATE)', N'Holy See (Vatican City State)', N'VAT', 336, 39)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'f4b5c4db-3ff6-4f5d-bc87-91aa29875795', N'QA', N'QATAR', N'Qatar', N'QAT', 634, 974)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'3415a2c2-3699-4e80-8f34-91ce4c3d0baf', N'BF', N'BURKINA FASO', N'Burkina Faso', N'BFA', 854, 226)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'05bc4b01-6e1e-444b-ae89-92061715d761', N'GE', N'GEORGIA', N'Georgia', N'GEO', 268, 995)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'd527b64e-b17b-4744-b510-92827b79f4fd', N'KZ', N'KAZAKHSTAN', N'Kazakhstan', N'KAZ', 398, 7)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'70bd96bd-255c-47ad-8f94-934a9f11b62e', N'IN', N'INDIA', N'India', N'IND', 356, 91)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'958039e4-df78-491d-b467-982975ded58c', N'BB', N'BARBADOS', N'Barbados', N'BRB', 52, 1246)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'c6e218bf-e950-4b99-91ec-99ee112cf0f8', N'GR', N'GREECE', N'Greece', N'GRC', 300, 30)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'a79d6e51-e04e-4406-be97-9ad6d060a8dc', N'MV', N'MALDIVES', N'Maldives', N'MDV', 462, 960)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'c9de946f-ea73-4728-9f21-9b6f10e49165', N'AL', N'ALBANIA', N'Albania', N'ALB', 8, 355)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'193060e6-a7c7-4d6f-8d3f-9d96f59f514e', N'PL', N'POLAND', N'Poland', N'POL', 616, 48)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'38c4f2c1-64cb-42e3-9584-9d9962c37f27', N'LK', N'SRI LANKA', N'Sri Lanka', N'LKA', 144, 94)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'2d6f8ba9-3a66-4fe8-9a31-9da28fb423f1', N'VU', N'VANUATU', N'Vanuatu', N'VUT', 548, 678)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'04cc0b49-73f1-41de-b577-9db89d29a835', N'DK', N'DENMARK', N'Denmark', N'DNK', 208, 45)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'a8efd0d0-0a5b-42f8-baca-9f3f725510cf', N'LC', N'SAINT LUCIA', N'Saint Lucia', N'LCA', 662, 1758)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'18bf29bd-693f-44e5-984a-9f9fe9f5a88b', N'NR', N'NAURU', N'Nauru', N'NRU', 520, 674)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'a39adc7d-2cd0-4948-9add-a0dececd0e2e', N'TM', N'TURKMENISTAN', N'Turkmenistan', N'TKM', 795, 7370)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'c63d4123-d384-4624-b6ab-a0f1594eb66a', N'GU', N'GUAM', N'Guam', N'GUM', 316, 1671)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'5c45ba73-248e-4855-b3de-a127adf4f4ef', N'CN', N'CHINA', N'China', N'CHN', 156, 86)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'c35088f4-e9db-482f-a1dc-a1fbafc16d30', N'KM', N'COMOROS', N'Comoros', N'COM', 174, 269)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'0552e9a5-9b94-4ca6-aa2d-a24f87c24c52', N'BM', N'BERMUDA', N'Bermuda', N'BMU', 60, 1441)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'e818d044-a428-4063-8260-a4f10b3c7e2c', N'SM', N'SAN MARINO', N'San Marino', N'SMR', 674, 378)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'77616f28-dcda-47e8-8fd9-a7049da32e86', N'GF', N'FRENCH GUIANA', N'French Guiana', N'GUF', 254, 594)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'073a692a-ec6d-4690-8fa5-a7080caf019d', N'MA', N'MOROCCO', N'Morocco', N'MAR', 504, 212)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'80216b31-d694-4f6c-868f-a78da2eebd0a', N'AZ', N'AZERBAIJAN', N'Azerbaijan', N'AZE', 31, 994)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'06e139f1-8715-4708-be03-a82a919f39c9', N'KY', N'CAYMAN ISLANDS', N'Cayman Islands', N'CYM', 136, 1345)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'f22829c1-4845-402c-8804-a93d49f6f5c1', N'TO', N'TONGA', N'Tonga', N'TON', 776, 676)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'41ec791a-7c93-4ef2-b129-a9fae9dafa33', N'MP', N'NORTHERN MARIANA ISLANDS', N'Northern Mariana Islands', N'MNP', 580, 1670)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'c4c15e9e-e559-41e9-870b-abd3dbb39af0', N'CH', N'SWITZERLAND', N'Switzerland', N'CHE', 756, 41)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'f4226c2b-a85e-4876-a8ca-acf300248c2d', N'RE', N'REUNION', N'Reunion', N'REU', 638, 262)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'960f5a55-8616-406c-be15-ad5dc2560d6f', N'WF', N'WALLIS AND FUTUNA', N'Wallis and Futuna', N'WLF', 876, 681)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'075c4344-159d-4f20-919b-adf95b105a9f', N'CY', N'CYPRUS', N'Cyprus', N'CYP', 196, 357)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'74b959bf-55cc-4e4b-ae04-ae7794c4826f', N'BT', N'BHUTAN', N'Bhutan', N'BTN', 64, 975)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'd4406519-9097-45de-9fe1-b04bc2e1c0a9', N'LI', N'LIECHTENSTEIN', N'Liechtenstein', N'LIE', 438, 423)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'2f30b36c-766f-4e84-8a7b-b07977179f05', N'ZM', N'ZAMBIA', N'Zambia', N'ZMB', 894, 260)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'34579b02-1041-4fff-98e4-b1b53d2f5cef', N'PY', N'PARAGUAY', N'Paraguay', N'PRY', 600, 595)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'4b98c86d-20bf-462b-a8d4-b3b61db0e74a', N'AF', N'AFGHANISTAN', N'Afghanistan', N'AFG', 4, 93)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'adf4a358-2e18-4bb4-80b9-b4e006e6d356', N'UY', N'URUGUAY', N'Uruguay', N'URY', 858, 598)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'9245d759-0bd0-4a71-89c2-b56b1af67dff', N'BZ', N'BELIZE', N'Belize', N'BLZ', 84, 501)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'ead817f8-5e4e-48f7-84d7-b6fc281cd89f', N'VE', N'VENEZUELA', N'Venezuela', N'VEN', 862, 58)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'ec620768-35e0-46c9-ad27-b80c9371a6dc', N'EE', N'ESTONIA', N'Estonia', N'EST', 233, 372)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'84f63767-a951-4b43-8fdb-b8e36f31852a', N'UM', N'UNITED STATES MINOR OUTLYING ISLANDS', N'United States Minor Outlying Islands', NULL, NULL, 1)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'fbfcc793-8d94-45f5-ab2e-b94dc7eafa77', N'NA', N'NAMIBIA', N'Namibia', N'NAM', 516, 264)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'79e7cc8c-100d-4d47-b41f-ba3f9d1ea571', N'BJ', N'BENIN', N'Benin', N'BEN', 204, 229)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'7500bfb5-d883-4827-b08f-ba7026da924d', N'AT', N'AUSTRIA', N'Austria', N'AUT', 40, 43)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'bf638e3f-7960-4974-9535-bbc229219af0', N'EH', N'WESTERN SAHARA', N'Western Sahara', N'ESH', 732, 212)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'603fa700-d960-4c28-b75f-bd3dcd57426d', N'PR', N'PUERTO RICO', N'Puerto Rico', N'PRI', 630, 1787)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'ff0c9e5f-97c1-4294-9515-bd76debbca77', N'TN', N'TUNISIA', N'Tunisia', N'TUN', 788, 216)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'8bfd38eb-0629-4364-bc39-c01d21654fd7', N'NI', N'NICARAGUA', N'Nicaragua', N'NIC', 558, 505)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'2797a669-0aed-4c41-980d-c0dbdd78a8bf', N'CU', N'CUBA', N'Cuba', N'CUB', 192, 53)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'd4ca11c2-e99a-462d-97af-c2e3cb4b5625', N'MN', N'MONLIA', N'Monlia', N'MNG', 496, 976)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'09455b10-08e7-404f-8b8c-c4687533148a', N'GM', N'GAMBIA', N'Gambia', N'GMB', 270, 220)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'581d9c03-bf58-4b84-b113-c54641fb3f9c', N'LT', N'LITHUANIA', N'Lithuania', N'LTU', 440, 370)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'0ba4cb78-9306-48b1-9c20-c588dfbfafb4', N'GI', N'GIBRALTAR', N'Gibraltar', N'GIB', 292, 350)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'f9983c0a-a1ed-423d-bce3-c7c87b3135c3', N'OM', N'OMAN', N'Oman', N'OMN', 512, 968)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'098ed35d-f46e-44f2-a0d2-c84a2194b76a', N'BI', N'BURUNDI', N'Burundi', N'BDI', 108, 257)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'a011ad18-7834-480f-ba0c-c897c9c1ef93', N'ST', N'SAO TOME AND PRINCIPE', N'Sao Tome and Principe', N'STP', 678, 239)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'e1d93dd3-fd1e-498c-931b-c8dffe29b42d', N'MU', N'MAURITIUS', N'Mauritius', N'MUS', 480, 230)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'8f2af1a6-54b3-4632-8126-c95d38316e8b', N'GT', N'GUATEMALA', N'Guatemala', N'GTM', 320, 502)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'21ceb46d-7d7a-4b45-bb8d-ca9384334abe', N'PT', N'PORTUGAL', N'Portugal', N'PRT', 620, 351)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'f06c4a69-d36d-4158-a672-cbadb2f22e3d', N'MY', N'MALAYSIA', N'Malaysia', N'MYS', 458, 60)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'784895d6-01d8-4661-b484-cbb45889ba68', N'AW', N'ARUBA', N'Aruba', N'ABW', 533, 297)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'015f9240-8666-4754-abd2-cc159ff84c95', N'DJ', N'DJIBOUTI', N'Djibouti', N'DJI', 262, 253)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'cb7e90cb-7303-40de-88cf-cc7f21e5007a', N'BD', N'BANGLADESH', N'Bangladesh', N'BGD', 50, 880)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'fa8c8a6e-da98-48ae-b37e-cd326f5941da', N'HK', N'HONG KONG', N'Hong Kong', N'HKG', 344, 852)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'bd32d2da-35e3-4067-b5d9-cd4f4ceb15c8', N'MO', N'MACAO', N'Macao', N'MAC', 446, 853)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'36af328e-7508-42de-9e72-cd741aa4ba45', N'PA', N'PANAMA', N'Panama', N'PAN', 591, 507)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'3eaa7c82-8dff-4db8-ab79-cdf9a11855a6', N'MS', N'MONTSERRAT', N'Montserrat', N'MSR', 500, 1664)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'e5717722-530c-4cd6-9471-d002f07aa9fe', N'AM', N'ARMENIA', N'Armenia', N'ARM', 51, 374)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'7f0e1b54-d9e5-4e21-9c6c-d360e4b0d88f', N'IR', N'IRAN, ISLAMIC REPUBLIC OF', N'Iran, Islamic Republic of', N'IRN', 364, 98)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'8196e2cc-2755-4487-9f19-d4e92a7c3e17', N'VN', N'VIET NAM', N'Viet Nam', N'VNM', 704, 84)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'eec8eca7-99d8-4c00-afce-d56a10afde10', N'SC', N'SEYCHELLES', N'Seychelles', N'SYC', 690, 248)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'db02e84a-18a3-4472-a16a-d8e26a61fee7', N'EC', N'ECUADOR', N'Ecuador', N'ECU', 218, 593)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'44acbac5-7357-40bc-9e37-da3858d5557b', N'TC', N'TURKS AND CAICOS ISLANDS', N'Turks and Caicos Islands', N'TCA', 796, 1649)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'e0c82366-40cf-4fea-ad80-db345fa49a6f', N'IE', N'IRELAND', N'Ireland', N'IRL', 372, 353)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'56db807d-39e5-4e2b-890f-db9bb991fcb4', N'AQ', N'ANTARCTICA', N'Antarctica', NULL, NULL, 0)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'19391a45-e654-4601-8efe-dcb9cca67afd', N'AE', N'UNITED ARAB EMIRATES', N'United Arab Emirates', N'ARE', 784, 971)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'17ed8027-26dd-43b4-a37b-dd98776dbe49', N'KN', N'SAINT KITTS AND NEVIS', N'Saint Kitts and Nevis', N'KNA', 659, 1869)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'e0f44d83-f032-4e46-9594-ddb93b9a192b', N'SH', N'SAINT HELENA', N'Saint Helena', N'SHN', 654, 290)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'3ae88e44-915d-4a0f-838f-df21c9e6d68f', N'MG', N'MADAGASCAR', N'Madagascar', N'MDG', 450, 261)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'811ae8e1-7a8c-453c-893d-df6cffbaba1f', N'CS', N'SERBIA AND MONTENEGRO', N'Serbia and Montenegro', NULL, NULL, 381)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'0b90fa45-443a-46b2-8398-dfb88599532f', N'JM', N'JAMAICA', N'Jamaica', N'JAM', 388, 1876)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'54109ba5-15d2-41bc-bacb-dfefcc5319e1', N'NU', N'NIUE', N'Niue', N'NIU', 570, 683)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'af165b67-d2ed-4035-a65b-e1304c9f5831', N'FJ', N'FIJI', N'Fiji', N'FJI', 242, 679)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'a29628fe-d541-49dc-af09-e2906366d015', N'PM', N'SAINT PIERRE AND MIQUELON', N'Saint Pierre and Miquelon', N'SPM', 666, 508)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'6aca7ef8-9ed2-4dfa-a7cd-e35708463569', N'BR', N'BRAZIL', N'Brazil', N'BRA', 76, 55)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'fa7e63dd-7136-4290-8b02-e45c5a25de3d', N'HU', N'HUNGARY', N'Hungary', N'HUN', 348, 36)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'f37cf81c-b30e-448a-98b6-e8fe5fa2a754', N'VG', N'VIRGIN ISLANDS, BRITISH', N'Virgin Islands, British', N'VGB', 92, 1284)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'da33d235-fc52-4b00-903b-eac0ab2fdef3', N'FM', N'MICRONESIA, FEDERATED STATES OF', N'Micronesia, Federated States of', N'FSM', 583, 691)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'2f7cd4bf-369f-4da5-9335-eb39d77da04e', N'MK', N'MACEDONIA, THE FORMER YUSLAV REPUBLIC OF', N'Macedonia, the Former Yuslav Republic of', N'MKD', 807, 389)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'6dce09d8-5645-4470-9e01-ec351812ccf7', N'CF', N'CENTRAL AFRICAN REPUBLIC', N'Central African Republic', N'CAF', 140, 236)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'1f36d607-94c5-419e-9a28-ec42ee7a3235', N'CO', N'COLOMBIA', N'Colombia', N'COL', 170, 57)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'7faf4e88-89cc-4439-8d60-ec8395431edb', N'GQ', N'EQUATORIAL GUINEA', N'Equatorial Guinea', N'GNQ', 226, 240)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'20984059-9b4d-4ff4-996e-edcff527cdaf', N'GA', N'GABON', N'Gabon', N'GAB', 266, 241)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'37b1e219-9128-47b2-b301-ee1457926f69', N'TL', N'TIMOR-LESTE', N'Timor-Leste', NULL, NULL, 670)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'9b094856-5117-464b-b1b5-ee9009c46c8d', N'SR', N'SURINAME', N'Suriname', N'SUR', 740, 597)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'274fba8a-6d3d-48c5-bd3b-efc7020dde38', N'BE', N'BELGIUM', N'Belgium', N'BEL', 56, 32)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'712922ba-feaa-4c69-9561-f3b1bb1f1e23', N'CK', N'COOK ISLANDS', N'Cook Islands', N'COK', 184, 682)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'cdb3fcfb-ef5a-414d-a7b0-f3fd92e9f309', N'PF', N'FRENCH POLYNESIA', N'French Polynesia', N'PYF', 258, 689)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'ce40e741-2918-44fa-a548-f4322029a9e4', N'TH', N'THAILAND', N'Thailand', N'THA', 764, 66)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'3303f90b-55aa-4d1f-859a-f4f7292ae052', N'RO', N'ROMANIA', N'Romania', N'ROM', 642, 40)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'8ba8eae2-ed97-4c38-9e95-f592b262e10c', N'SZ', N'SWAZILAND', N'Swaziland', N'SWZ', 748, 268)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'8af8c492-3630-4dd3-bb10-f790653fabcf', N'NZ', N'NEW ZEALAND', N'New Zealand', N'NZL', 554, 64)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'0f60a741-0f0c-4fcf-a16e-f7eadd9b9fa0', N'KG', N'KYRGYZSTAN', N'Kyrgyzstan', N'KGZ', 417, 996)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'efa773c1-69db-41b4-985b-f7ee8a95d189', N'ES', N'SPAIN', N'Spain', N'ESP', 724, 34)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'0b514a43-9b91-4395-85a1-fa23f6832a83', N'UZ', N'UZBEKISTAN', N'Uzbekistan', N'UZB', 860, 998)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'4cace679-c12b-41e0-896b-fa98dfc2fea1', N'TK', N'TOKELAU', N'Tokelau', N'TKL', 772, 690)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'04894ecf-ade9-4d76-ba1f-fc95601a8d92', N'IO', N'BRITISH INDIAN OCEAN TERRITORY', N'British Indian Ocean Territory', NULL, NULL, 246)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'001be1fa-4332-4e1f-8841-fd851dce88a6', N'IQ', N'IRAQ', N'Iraq', N'IRQ', 368, 964)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'5b119bd8-43b4-4367-a984-fd9d5c39873a', N'ML', N'MALI', N'Mali', N'MLI', 466, 223)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'78e6b6c8-9aa1-4f79-93a6-fef5b57f7ab6', N'IT', N'ITALY', N'Italy', N'ITA', 380, 39)

INSERT [dbo].[Countries] ([Id], [Iso], [Name], [NiceName], [Iso3], [NumCode], [PhoneCode]) VALUES (N'9ef944f7-6254-4d2b-8f7f-ffd1ddc3deb8', N'JO', N'JORDAN', N'Jordan', N'JOR', 400, 962)

COMMIT TRANSACTION