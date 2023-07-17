<h1 class="code-line" data-line-start=0 data-line-end=1><a id="Sync_Data_using_API_0"></a>Sync Data using API</h1>
<h2 class="code-line" data-line-start=1 data-line-end=2><a id="Syncing_of_Data_between_WooCommerce_and_CjDropshipping_1"></a>Syncing of Data between WooCommerce and CjDropshipping</h2>
<h2 class="code-line" data-line-start=4 data-line-end=5><a id="Features_4"></a>Features</h2>
<ul>
<li class="has-line-data" data-line-start="6" data-line-end="7">It has 2 Schedule jobs which are configured using CronExpression in the web.config</li>
<li class="has-line-data" data-line-start="7" data-line-end="8">WooCommerceSchedule job will fetch all the products from the website and save it into the database</li>
<li class="has-line-data" data-line-start="8" data-line-end="10">CjDropshippingScheduler will fetch each product with the sku and update the price and stock information in the woocommerce</li>
</ul>
<h2 class="code-line" data-line-start=10 data-line-end=11><a id="Configurations_10"></a>Configurations</h2>
<p class="has-line-data" data-line-start="12" data-line-end="13">Following are the configurations in web.config</p>
<table class="table table-striped table-bordered">
<thead>
<tr>
<th>Key</th>
<th>Description</th>
</tr>
</thead>
<tbody>
<tr>
<td>AddOnPrice</td>
<td>Price you want to add in CjDropshipping price</td>
</tr>
<tr>
<td>WooCommerceUrl</td>
<td>URL for the woocommerce API</td>
</tr>
<tr>
<td>WooCommerceKey</td>
<td>Key for the woocommerce API</td>
</tr>
<tr>
<td>WooCommerceSecret</td>
<td>Secret for the woocommerce API</td>
</tr>
<tr>
<td>CjDropShippingCronExpression</td>
<td>Cron Expression for the woocommerce API</td>
</tr>
<tr>
<td>CjAccessUrl</td>
<td>URL for the CjDropshipping API</td>
</tr>
<tr>
<td>CjAccessToken</td>
<td>Access Token for the CjDropshipping API</td>
</tr>
<tr>
<td>CjDropShippingCronExpression</td>
<td>Cron Expression for the CjDropshipping API</td>
</tr>
<tr>
<td>ConnectionString</td>
<td>Connection string of the database. It is situated in the Log4net xml also.</td>
</tr>
</tbody>
</table>
<p class="has-line-data" data-line-start="26" data-line-end="27">Create the Database “SyncData” in the SQL Server. After that run the script from the path “~/SyncData/SyncData/DatabaseScripts/SyncDataDatabaseScript.sql”</p>

</body></html>
