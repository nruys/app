using System;
using System.Collections.Generic;
using System.Linq;

namespace app.utility.container
{
  public class DependencyFactories : IFindFactoriesForDependencies
  {
    IEnumerable<ICreateOneDependency> possible_factories;
    MissingFactory_Behaviour _missingFactoryBehaviour;

    public DependencyFactories(IEnumerable<ICreateOneDependency> possible_factories, MissingFactory_Behaviour missingFactoryBehaviour)
    {
        this.possible_factories = possible_factories;
        this._missingFactoryBehaviour = missingFactoryBehaviour;
    }

    public ICreateOneDependency get_factory_that_can_create(Type dependency)
    {
        try
        {
            return possible_factories.First(x => x.can_create(dependency));
        } catch(Exception)
        {
            throw  _missingFactoryBehaviour(dependency);
        }
    }
  }
}