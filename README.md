add a settings.json in ReproDistinctConsole to match the expected settings file
	<ItemGroup>
	  <None Update="settings.json">
	    <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
	  </None>
	</ItemGroup>

 run console project it will give you the sql query with the distinct problem
SELECT DISTINCT [a].[Id], [a].[AtlasId], [a].[PassId], [a].[LastControlDateTime], [a].[LastSendingDateTime], [a].[ReferenceId], [a].[AtlasGroupId], [a].[StatutAffaire]
FROM [Affaires] AS [a]
