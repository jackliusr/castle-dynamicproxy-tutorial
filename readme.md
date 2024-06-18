# Dynamic Proxy Tutorial

Most of the contents are from https://kozmic.net/dynamic-proxy-tutorial/. I added some small supplement classes which are not in the series. All the credits go to Krzysztof Koźmic


1. Introduction
1. The what, why and how
1. Selecting which methods to intercept
1. Breaking hard dependencies
1. InterceptorSelector, fine grained control over proxying
1. Castle Dynamic Proxy tutorial part VI: handling non-virtual methods

	[NonVirtualMemberNotification is renamed to NonProxyableMemberNotification](https://github.com/castleproject/Core/blob/bf969ab1d6c0fbcb7c7c26532810b36a4d20d6ae/CHANGELOG.md?plain=1#L312)


1. Kinds of proxy objects

   Create proxy with parameters and interfaces.
	```cs
		CreateClassProxy(Type classToProxy,
		  Type[] additionalInterfacesToProxy, 
		  ProxyGenerationOptions options,
		  object[] constructorArguments, 
		  params IInterceptor[] interceptors)
	```
 
1. Interface proxy without target
1. Interface proxy with target
1. Interface proxies with target interface
1. When one interface is not enough
1. Caching
1. Mix in this, mix in that
1. Persisting proxies
1. Patterns and Antipatterns
